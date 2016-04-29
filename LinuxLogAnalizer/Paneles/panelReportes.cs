using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LinuxLogAnalizer.Paneles
{
    public partial class panelReportes : UserControl
    {
        public panelReportes()
        {
            InitializeComponent();
            foreach (Config.Reporte rpt in commons.Configuracion.Reportes)
            {
                cmbConReport.Items.Add(rpt);
            }
            if (cmbConReport.Items.Count > 0)
                cmbConReport.SelectedIndex = 0;

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbConReport.Items.Count == 0)
                return;
            if (cmbConReport.SelectedItem != null)
            {
                try
                {
                    Config.Reporte rpt = (Config.Reporte)cmbConReport.Items[cmbConReport.SelectedIndex];
                    clsRepo repo = new clsRepo();
                    DataTable dt = repo.Seleccionar(rpt.SQL);
                    ExcelReporter.Exporter exporter = new ExcelReporter.Exporter();
                    exporter.AgregarWorkSheet(dt, cleantext(rpt.Nombre));
                    exporter.CrearArchivoExcelDialog();
                }
                catch (Exception ex)
                {

                    string mensaje = "";
                    while (ex != null)
                    {
                        mensaje = mensaje + ex.Message + "\n\n";
                        ex = ex.InnerException;
                    }

                    commons.mensajeError("El reporte regresó el siguiente error:\n" + mensaje, "Error al generar el reporte");
                }
            }

        }
        private string cleantext(string texto)
        {
            return Regex.Replace(texto, @"[\~|\@|\#|\$|\^|\&|\*|\(|\)|\-|_|\+|\=|\[|\]|\{|\}|\||\\|\,|\.|\?|\:]","");
        }
    }
}

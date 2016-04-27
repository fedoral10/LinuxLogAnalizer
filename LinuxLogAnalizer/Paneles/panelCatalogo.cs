using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleExcelImport;
using LinuxLogAnalizer.Excel;
using System.IO;

namespace LinuxLogAnalizer.Paneles
{
    public partial class panelCatalogo : UserControl
    {
        public panelCatalogo()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                readFileToImport();
            }
            catch (Exception ex)
            {
                commons.mensajeError(ex.Message, "Error");
            }
        }
        private void readFileToImport()
        {
            List<string> archivos = commons.showOpenFile("Archivos de Excel (*.xlsx)|*.xlsx", true);

            if (archivos == null)
                return;

            clsRepo repo = new clsRepo();
            foreach (string archivo in archivos)
            {
                var data = File.ReadAllBytes(archivo);
                ImportFromExcel import = new ImportFromExcel();
                import.LoadXlsx(data);

                List<UsuarioExcel> output = import.ExcelToList<UsuarioExcel>(0, 1);

                foreach (UsuarioExcel usr in output)
                {
                    repo.Insertar<Dominio.Entidad>(usr.getEntidad());
                }
            }
        }

        private void btnIp_Click(object sender, EventArgs e)
        {
            Forms.frmAddIp ip = new Forms.frmAddIp();
            ip.ShowDialog();
        }

        private void btnIPsMasivo_Click(object sender, EventArgs e)
        {
            List<string> archivos = commons.showOpenFile("Archivos de Excel (*.xlsx)|*.xlsx", true);

            if (archivos == null)
                return;

            if(archivos.Count <= 0)
                return;

            foreach (string archivo in archivos)
            {
                byte[] bits = File.ReadAllBytes(archivo);
                ImportFromExcel importer = new ImportFromExcel();
                bool res = importer.LoadXlsx(bits);
                List<Excel.Ip> excel_rows = importer.ExcelToList<Excel.Ip>(0, 1);
                clsRepo repo = new clsRepo();
                foreach (Excel.Ip ip in excel_rows)
                {
                    repo.Insertar<Dominio.Ip>(ip.getDBip());
                }
            }
        }
    }
}

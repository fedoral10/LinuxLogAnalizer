using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxLogAnalizer.Paneles
{
    public partial class panelArchLogs : UserControl
    {

        private frmWait _waitScreen;

        private Form _formPadre;

        public void setFormPadre(Form frm)
        {
            this._formPadre = frm;
        }

        public panelArchLogs()
        {
            InitializeComponent();
            this._waitScreen=new frmWait();
            this._waitScreen.Parent = this._formPadre;
            clsRepo repo = new clsRepo();
            foreach (string clase in repo.getEntidadesNombre())
            {
                cmbTabla.Items.Add(clase);
            }
            if (cmbTabla.Items.Count > 0)
                cmbTabla.SelectedIndex = 0;
        }

        private void btnPasswd_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_passwd>(this._waitScreen);
        }

        private void btnShadow_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_shadow>(this._waitScreen);
        }

        private void btnSecure_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_secure>(this._waitScreen);
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_group>(this._waitScreen);
        }

        private void btnLastb_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_lastb>(this._waitScreen);
        }

        private void btnClearTable_Click(object sender, EventArgs e)
        {
            try
            {
                clsRepo repo = new clsRepo();
                repo.Actualizacion("delete from " + cmbTabla.SelectedItem.ToString());
                commons.mensajeInformativo("Tabla " + cmbTabla.SelectedItem.ToString() + " limpia!", "Limpieza de tablas");
            }
            catch(Exception ex)
            {
                commons.mensajeError(ex.Message, "Error");
            }
        }

        private void btnClearAllTables_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro que desea vaciar todo el contenido de la base de datos?", "Limpiar Tablas", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.No)
                return;

            try{
                clsRepo repo = new clsRepo();
                foreach (object tabla in cmbTabla.Items)
                {
                    repo.Actualizacion("delete from " + tabla.ToString());
                }
            }catch(Exception ex)
            {
                commons.mensajeError(ex.Message, "Error");
            }
        }

        
    }
}

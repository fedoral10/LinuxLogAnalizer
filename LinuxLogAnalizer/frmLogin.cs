using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;


namespace LinuxLogAnalizer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.txtDescripcion.Enabled = false;
        }
        /*
         * OU=TCN,DC=TCN,DC=COM,DC=NI
         * 
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            /*foreach (string s in AD.ADScopes())
            {
                Console.WriteLine(s);
            }*/
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            NHelper.setConnectionString(this.txtUser.Text, txtPassword.Text,txtDB.Text, txtServer.Text, txtPort.Value.ToString());
            try
            {
                using (ISession session = NHelper.OpenSession())
                {
                    /*Crear revision*/
                    if (chkCrearRevision.Checked)
                    {
                        clsRepo repo = new clsRepo();
                        Dominio.Revision rev = new Dominio.Revision();

                        rev.descripcion = txtDescripcion.Text;

                        repo.Insertar<Dominio.Revision>(rev);
                        commons.Revision_Actual = rev;
                    }
                    else
                    { 
                        /*Usa revision ya hecha*/

                        if (cmbRevision.Items.Count > 0)//si se selecciono una revision
                        {
                            commons.Revision_Actual = (Dominio.Revision)cmbRevision.SelectedItem;
                        }
                        else
                        {
                            commons.mensajeInformativo("Seleccione una revision o cree una nueva", this.Text);
                            return;
                        }

                    }


                    /*Prueba de conexion*/
                    this.Visible = false;

                    frmMain i = new frmMain();
                    i.ShowDialog();

                    Close();
                }
            }
            catch (Exception ex)
            {
                string mensaje = "";
                while (ex != null)
                {
                    mensaje = mensaje + "##" + ex.Message + "\n";
                    ex = ex.InnerException;
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter&& this.ActiveControl.GetType() != typeof(Button))
            {
                //MessageBox.Show("You pressed the F1 key");
                SendKeys.Send("{TAB}");
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnAD_Click(object sender, EventArgs e)
        {
            ADSI.Forms.Usuario.frmUsuarios usr = new ADSI.Forms.Usuario.frmUsuarios();
            usr.ShowDialog();
        }

        private void chkCrearRevision_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCrearRevision.Checked)
                this.txtDescripcion.Enabled = true;
            else
                this.txtDescripcion.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            NHelper.setConnectionString(this.txtUser.Text, txtPassword.Text, txtDB.Text, txtServer.Text, txtPort.Value.ToString());
            clsRepo repo = new clsRepo();
            try
            {
                IList<Dominio.Revision> lista = repo.Seleccionar<Dominio.Revision>();
                if(lista != null)
                    foreach (Dominio.Revision r in lista)
                    {
                        cmbRevision.Items.Add(r);
                    }
            }
            catch (Exception ex)
            {
                commons.mensajeError(ex.Message, this.Text);
            }
            if (cmbRevision.Items.Count > 0)
            {
                cmbRevision.SelectedIndex = 0;
            }
        }

        

    }
}

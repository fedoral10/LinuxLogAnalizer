using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxLogAnalizer.Forms
{
    public partial class frmAddIp : frmBaseTool
    {
        public frmAddIp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiar()
        {
            txtIp.Text = null;
            txtDescripcion.Text = "";
            txtIDUsuario.Text = null;
        }

        private void btnAddContinue_Click(object sender, EventArgs e)
        {
            if (!verficaIp(txtIp.Text))
            {
                commons.mensajeInformativo("Verifique la IP ingresada", this.Text);
                return;
            }

            clsRepo repo = new clsRepo();
            Dominio.Ip ip = new Dominio.Ip();
            ip.descripcion = txtDescripcion.Text;
            ip.ip = txtIp.Text;
            ip.samaccountname = txtIDUsuario.Text;
            try
            {
                repo.Insertar<Dominio.Ip>(ip);
                limpiar();
            }
            catch (Exception ex)
            {
                commons.mensajeError(ex.Message,this.Text);
            }

        }

        private bool verficaIp(string texto)
        {
            bool retorno=false;
            if (Regex.IsMatch(texto, "^([0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3})$"))
                retorno = true;

            string[] arr = texto.Split('.');
            foreach (string numero in arr)
            {
                if (int.Parse(numero) > 255)
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!verficaIp(txtIp.Text))
            {
                commons.mensajeInformativo("Verifique la IP ingresada", this.Text);
                return;
            }

            clsRepo repo = new clsRepo();
            Dominio.Ip ip = new Dominio.Ip();
            ip.descripcion = txtDescripcion.Text;
            ip.ip = txtIp.Text;
            ip.samaccountname = txtIDUsuario.Text;
            try
            {
                repo.Insertar<Dominio.Ip>(ip);
                this.Close();
            }
            catch (Exception ex)
            {
                commons.mensajeError(ex.Message, this.Text);
            }
        }
    }
}

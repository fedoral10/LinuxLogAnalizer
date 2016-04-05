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

        
    }
}

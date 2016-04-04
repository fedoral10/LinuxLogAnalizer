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
        public panelArchLogs()
        {
            InitializeComponent();
        }

        private void btnPasswd_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_passwd>();
        }

        private void btnShadow_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_shadow>();
        }

        private void btnSecure_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_secure>();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_group>();
        }

        private void btnLastb_Click(object sender, EventArgs e)
        {
            commons.execAnalizador<Analizador_lastb>();
        }

        
    }
}

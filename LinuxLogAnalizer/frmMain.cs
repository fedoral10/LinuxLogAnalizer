using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinuxLogAnalizer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();



            //Analizador a = new Analizador_passwd(@"C:\Users\njn04571\Desktop\VBox\passwd");
            //Analizador a = new Analizador_lastb(@"C:\Users\njn04571\Desktop\VBox\lastb.txt");
            //Analizador a = new Analizador_secure(@"C:\Users\njn04571\Desktop\VBox\secure.txt");
            //Analizador a = new Analizador_secure(@"C:\Users\njn04571\Desktop\VBox\secure");
            //NHelper.setConnectionString("postgres", "123", "linux", "localhost", "5432");
            //a.insertarEnDB();

        }

        private void archivosDeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*panelMain.Controls.Clear();
            Paneles.panelArchLogs p = new Paneles.panelArchLogs();
            panelMain.Controls.Add(p);*/

            commons.insertarPanel(new Paneles.panelArchLogs(), this.panelMain);
        }

        private void activeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADSI.Forms.Usuario.frmUsuarios u = new ADSI.Forms.Usuario.frmUsuarios();
            u.ShowDialog();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commons.insertarPanel(new Paneles.panelReportes(), this.panelMain);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commons.insertarPanel(new Paneles.panelCatalogo(), this.panelMain);
        }
    }
}

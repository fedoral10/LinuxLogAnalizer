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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            //Analizador a = new Analizador_passwd(@"C:\Users\njn04571\Desktop\VBox\passwd");
            //Analizador a = new Analizador_lastb(@"C:\Users\njn04571\Desktop\VBox\lastb.txt");
            //Analizador a = new Analizador_secure(@"C:\Users\njn04571\Desktop\VBox\secure.txt");
            Analizador a = new Analizador_secure(@"C:\Users\njn04571\Desktop\VBox\secure");
            NHelper.setConnectionString("postgres", "123", "linux", "localhost", "5432");
            a.insertarEnDB();

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinuxLogAnalizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                log4net.Config.XmlConfigurator.Configure();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //NHelper.setConnectionString("postgres", "123", "linux", "localhost", "5432");
                //Application.Run(new frmWait());
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
                string mensaje = "";
                while (ex != null)
                { 
                    mensaje = mensaje +"##"+ ex.Message+"\n";
                    ex = ex.InnerException;
                }
                System.Windows.Forms.MessageBox.Show(mensaje, "Error");
            }
        }
        
    }
}

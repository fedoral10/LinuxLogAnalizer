using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinuxLogAnalizer
{
    class commons
    {
        public static ILog logger = LogManager.GetLogger("info");
        private static Form _frmPadre;

        public static void setFormPadre(Form frm)
        {
            _frmPadre = frm;
        }

        private static void read(string path)
        {
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(f, Encoding.UTF8, false, 10240);
            string linea = "";
            int x = 0;
            while ((linea = reader.ReadLine()) != null)
            {
                if (x == 1)
                    Console.WriteLine(linea);
                x++;
                /*Console.WriteLine(x);
                x++;
                if (x == 100000)
                    break;*/
            }
        }
        private static void read1(string path)
        {
            var lista = File.ReadLines(path);
            int x = 0;
            foreach (string linea in lista)
            {

                if (x == 1)
                    Console.WriteLine(linea);
                x++;
                //break;
                /*Console.WriteLine(x);
                x++;
                if (x == 100000)
                    break;
                 * */
            }
        }

        public static List<string> leerArchiv(string filename)
        {
            return File.ReadAllLines(filename).OfType<string>().ToList<string>();
        }
        public static string[] leerArchivoArray(string filename)
        {
            return File.ReadAllLines(filename);
        }

        public static List<string> showOpenFile(string filtro, bool multiselect)
        {
            List<string> retorno = null;

            OpenFileDialog fl = new OpenFileDialog();

            fl.Filter = filtro;
            fl.Multiselect = multiselect;
            if (fl.ShowDialog() == DialogResult.OK)
            { 
                retorno = fl.FileNames.ToList<string>();
            }

            return retorno;
        }
        public static void execAnalizador<T>(frmWait wait)where T:Analizador
        {
            List<string> archivos = commons.showOpenFile("Todos los Archivos(*.*)|*.*", true);
            if (archivos != null)
            {
                Task t = Task.Run(() =>
                {
                    _frmPadre.Invoke((MethodInvoker)delegate
                    {
                        _frmPadre.Enabled = false;
                        _frmPadre.UseWaitCursor = true;
                    });
                    wait.Invoke((MethodInvoker)delegate
                    {
                        wait.label1.Text ="Por favor espere..."; // runs on UI thread
                    });
                    foreach (string archivo in archivos)
                    {
                        Analizador a = (T)Activator.CreateInstance(typeof(T), archivo);
                        a.insertarEnDB();
                    }
                });
                wait.Show();
                t.ContinueWith( a => {
                    wait.Invoke((MethodInvoker)delegate
                    {
                        wait.Hide(); // runs on UI thread
                    });
                    _frmPadre.Invoke((MethodInvoker)delegate
                    {
                        _frmPadre.Enabled = true;
                        _frmPadre.UseWaitCursor = false;
                    });
                });
                
                
            }
        }

        public static void insertarPanel(Control panel_origen, Control panel_destino)
        {
            panel_destino.Controls.Clear();
            //Paneles.panelArchLogs p = new Paneles.panelArchLogs();
            panel_destino.Controls.Add(panel_origen);
        }
    }
}

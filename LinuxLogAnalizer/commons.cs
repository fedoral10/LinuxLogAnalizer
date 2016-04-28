using LinuxLogAnalizer.Config;
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

        //private Dominio.Revision _revision;

        public static Dominio.Revision Revision_Actual { get; set; }

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

        public static void mensajeInformativo(string texto, string titulo)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void mensajeError(string texto, string titulo)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private static string confFile= "configuracion.xml";

        public static ConfigGlobal Configuracion{get;set;}

        public static ConfigGlobal readConfig()
        {
            if(File.Exists(confFile))
                Configuracion = Serializador.deserializar<ConfigGlobal>(confFile);
            else
            if(Configuracion==null)
            {
                Configuracion = new ConfigGlobal();
                Configuracion.usuario = "postgres";
                Configuracion.host = "localhost";
                Configuracion.puerto = "5432";
                //Configuracion.SetPassword("null");
                Configuracion.Reportes = standardReports();
                Serializador.serializar<ConfigGlobal>(Configuracion, confFile);
            }

            return Configuracion;
        }
        public static void writeConfig()
        {
            Serializador.serializar<ConfigGlobal>(Configuracion, confFile);
        }

        private static Reporte[] standardReports()
        {
            Reporte[] rpts= new Reporte[3];
            rpts[0] = new Reporte();
            rpts[0].Nombre = "Conexiones Únicas(lastb)";
            rpts[0].SQL = "select lb.username,lb.servicio,lb.ip from lastb";

            rpts[1] = new Reporte();
            rpts[1].Nombre = "Conexiones Exitosas(lastb,ip)";
            rpts[1].SQL = "select lb.username,lb.servicio,lb.ip, "+
            "(select case when i.samaccountname isnull then i.descripcion when trim(i.samaccountname) = '' then i.descripcion else i.samaccountname end from ip i "+
            "where i.ip = lb.ip limit 1) as id, " +
            " (select cn from ip i "+
            "inner join entidad e on i.samaccountname = e.samaccountname "+ 
            "where i.ip = lb.ip limit 1) as nombre,"+
            " (select description from ip i"+
            "inner join entidad e on i.samaccountname = e.samaccountname"+
            "where i.ip = lb.ip limit 1) as description,"+
            " (select department from ip i "+
            " inner join entidad e on i.samaccountname = e.samaccountname"+
            "where i.ip = lb.ip limit 1) as area"+
            " from ( "+
            "select distinct lb.username, "+
            "case when left(lb.servicio,3) = 'pts' then 'pts' else lb.servicio end, "+
            "lb.ip "+ 
            "from lastb lb "+
            ") lb";

            rpts[2] = new Reporte();
            rpts[2].Nombre = "Conexiones Fallidas(secure)";
            rpts[2].SQL = 
"/* new versiom sql punto 3******/"+
"select nconex,id_conexion,ip,cadena_conex,"+
"(select cn from ip i"+
"inner join entidad e on i.samaccountname = e.samaccountname"+
"where i.ip = lb.ip limit 1) as nombre,"+
" (select description from ip i"+
"inner join entidad e on i.samaccountname = e.samaccountname"+
"where i.ip = lb.ip limit 1) as description,"+
" (select department from ip i"+
"inner join entidad e on i.samaccountname = e.samaccountname"+
"where i.ip = lb.ip limit 1) as area"+
"from ("+
	"/*shh*/"+
	"select "+
	"count(*) as nconex,"+
	"id_conexion,"+
	"ip,cadena_conex from ("+
	"select mensaje,"+
	"replace(replace(cast(regexp_matches(mensaje,'for.*from') as text),'{\"for ',''),' from\"}','') as id_conexion,"+
	"replace(replace(cast(regexp_matches(mensaje,'([0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3})') as text),'{',''),'}','') as ip,"+
	"regexp_replace(mensaje, 'for.*','' ) as cadena_conex"+
	"from secure where proceso_id = 'sshd'"+
	") ssh "+
	"group by id_conexion, ip,cadena_conex"+
	"union"+
	"select count(*) as nconex,"+
	"id_conexion,"+
	"ip,"+
	"cadena_conex "+
	"from ("+
	"select"+
	"replace(replace( cast(regexp_matches(mensaje,'for.*on') as text),'{\"for ',''),' on\"}','') as id_conexion,"+
	"cast('' as text)  as ip,"+
	"replace(replace(cast(regexp_matches(mensaje,'(''[a-z| ]+'' [a-z]+)') as text),'{\"',''),'\"}','') as cadena_conex"+
	"from secure"+
	") su"+
	"group by "+
	"id_conexion,"+
	"ip,"+
	"cadena_conex"+
    ") lb";

            return rpts;
        }
        
    }
}

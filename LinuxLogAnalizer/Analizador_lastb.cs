using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinuxLogAnalizer
{
    class Analizador_lastb : Analizador
    {
        private string _filename;

        public Analizador_lastb(string archivo)
        {
            this._filename = archivo;
        }

        public override void insertarEnDB()
        {
            var lista = this.leerArchivo(_filename);
            clsRepo repo = new clsRepo();

            /*System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();*/
            Parallel.ForEach<string>(lista, linea =>
            //foreach(string linea in lista)
            {
                /*commons.logger.Info("testing info");
                commons.logger.Warn("testing warning");*/
                Dominio.Lastb lastb = getLastbLine(linea);
                if (lastb != null)
                {
                    repo.Insertar<Dominio.Lastb>(lastb);
                    
                               
                }
            });
            //Console.Write((stopWatch.ElapsedMilliseconds / 1000) + " segundos");

        }

        public Dominio.Lastb getLastbLine(string line)
        {
            Dominio.Lastb retorno;
            if (!esLineaLog(line))
                return null;

            retorno = new Dominio.Lastb();
            string fecha = null;
            line = depurarFecha(line,out fecha);

            string[] arreglo = Regex.Split(line," {2,}");
            retorno.revision = commons.Revision_Actual;
            switch (arreglo.Length )
            {
                case 3:
                    retorno.username = arreglo[0];
                    retorno.servicio = arreglo[1];
                    retorno.tiempoConexion = arreglo[2];
                    retorno.fecha = fecha;
                break;
                case 4:
                    retorno.username = arreglo[0];
                    retorno.servicio = arreglo[1];
                    retorno.ip = arreglo[2];
                    retorno.tiempoConexion = arreglo[3];
                    //retorno.fecha = arreglo[3];
                    //retorno.fechaValue = null;
                    retorno.fecha = fecha;
                break;
                case 5:
                    retorno.username = arreglo[0];
                    retorno.servicio = arreglo[1];
                    retorno.ip = arreglo[2];
                    retorno.fecha = arreglo[3];
                    //retorno.fechaValue = null;
                    retorno.tiempoConexion = arreglo[4];
                break;
                case 6:
                    retorno.username = arreglo[0];
                    retorno.servicio = arreglo[1];
                    retorno.ip = arreglo[2];
                    retorno.fecha = arreglo[3]+"  "+arreglo[4];;
                    //retorno.fechaValue = null;
                    retorno.tiempoConexion = arreglo[5];
                break;
                
                default:
                retorno = null;

                if (string.IsNullOrEmpty(line))
                    Console.WriteLine("linea vacia");
                else
                    Console.WriteLine("error con la siguiente linea:\n"+ line);
                break;
            }

            return retorno;
        }

        private string depurarFecha(string linea,out string fecha)
        { 
            fecha =Regex.Match(linea,"[A-Z][a-z]{2} [A-Z][a-z]{2} [ |0-9]{1,2} [0-9]{2}:[0-9]{2}( \\- ([a-z]+|[0-9]{2}:[0-9]{2}))?").Value;
            return linea.Replace(fecha,"");
        
        }

        private bool esLineaLog(string linea)
        {
            return Regex.IsMatch(linea, "[A-Z][a-z]{2} [A-Z][a-z]{2} [ |0-9]{1,2} [0-9]{2}:[0-9]{2}( \\- ([a-z]+|[0-9]{2}:[0-9]{2}))?");
        }

        private bool esIP(string texto)
        {
            return Regex.IsMatch(texto, "([0-9]{1,3}\\.){3}[0-9]{1,3}");
        }
    }
}

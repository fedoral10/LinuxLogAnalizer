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
            foreach (string linea in lista)
            {
                commons.logger.Info("testing info");
                commons.logger.Warn("testing warning");
                Dominio.Lastb lastb = getLastbLine(linea);
                if(lastb != null)
                    repo.Insertar<Dominio.Lastb>(lastb);
            }
        }

        public Dominio.Lastb getLastbLine(string line)
        {
            Dominio.Lastb retorno = new Dominio.Lastb();
            
            string[] arreglo = Regex.Split(line," {2,}");

            
            switch (arreglo.Length )
            {
                case 4:
                    retorno.username = arreglo[0];
                    retorno.servicio = arreglo[1];
                    retorno.ip = arreglo[2];
                    string tiempo_conexion = Regex.Match(arreglo[3], "\\(.*\\)").Value;
                    string fecha = arreglo[3].Replace(tiempo_conexion, "").Trim();
                    retorno.tiempoConexion = tiempo_conexion;
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
    }
}

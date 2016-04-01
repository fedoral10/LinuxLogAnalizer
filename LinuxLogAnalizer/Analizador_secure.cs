using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinuxLogAnalizer
{
    class Analizador_secure : Analizador
    {

        private string _filename;

        public Analizador_secure(string archivo)
        {
            this._filename = archivo;
        }

        public override void insertarEnDB()
        {
            var lista = this.leerArchivo(_filename);
            clsRepo repo = new clsRepo();
            foreach (string linea in lista)
            {
                Dominio.Secure secure = getSecureLine(linea);
                if(secure!=null)
                    repo.Insertar<Dominio.Secure>(secure);
            }
        }
        public Dominio.Secure getSecureLine(string line)
        {

            if (line.Contains("last message repeated"))
            {
                Console.WriteLine("linea ignorada");
                return null;
            }

            Dominio.Secure retorno=null;
            string linea_trabajada = "";
            try
            {
                retorno = new Dominio.Secure();
                linea_trabajada = line;

                if (Regex.IsMatch(line, "[A-Z][a-z]{2} {1,2}[0-9]{1,2} ([0-9]{2}:){2}[0-9]{2}"))
                    retorno.fechaHora = linea_trabajada.Substring(0, 15);
                else
                    retorno.fechaHora = linea_trabajada.Substring(0, 32);

                //Eliminar la fecha del string
                linea_trabajada = linea_trabajada.Replace(retorno.fechaHora, "").Trim();

                //Eliminar los IDs
                linea_trabajada = Regex.Replace(linea_trabajada, "\\[[\\. |0-9|A-Z|a-z]+\\]", "");

                //obtener solo el hostname y el servicio
                int indice_dp = linea_trabajada.IndexOf(":");
                string usuario_servicio = linea_trabajada.Substring(0, indice_dp);
                string[] arreglo = usuario_servicio.Split(' ');
                retorno.hostname = arreglo[0];
                retorno.procesoId = arreglo[1];

                //Eliminar el hostname y el servicio para dejar solo el mensaje

                linea_trabajada = linea_trabajada.Replace(usuario_servicio+":", "").Trim();


                retorno.mensaje = linea_trabajada;
            }
            catch 
            {
                Console.WriteLine("Error con la linea: \n" + line);
            }
            return retorno;
        }
    }
}

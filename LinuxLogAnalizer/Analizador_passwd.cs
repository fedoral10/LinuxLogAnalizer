using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinuxLogAnalizer
{
    class Analizador_passwd : Analizador
    {

        private string _filename;

        public Analizador_passwd(string archivo)
        {
            this._filename = archivo;
        }

        public override void insertarEnDB()
        {
            var lista = this.leerArchivo(_filename);
            clsRepo repo = new clsRepo();
            foreach (string linea in lista)
            { 
                Dominio.Passwd passwd = getPasswdLine(linea);
                if(passwd != null)
                    repo.Insertar<Dominio.Passwd>(passwd);
            }
        }

        public Dominio.Passwd getPasswdLine(string line) {
            Dominio.Passwd retorno = null;

            
            string[] arreglo = line.Split(':');
            if (arreglo != null)
            {
                if (arreglo.Length == 7)
                {
                    retorno = new Dominio.Passwd();
                    retorno.revision = commons.Revision_Actual;
                    retorno.usuario = arreglo[0];
                    retorno.password = arreglo[1];
                    retorno.uid = int.Parse(arreglo[2]);
                    retorno.gid = int.Parse(arreglo[3]);
                    retorno.descripcion = arreglo[4];
                    retorno.home = arreglo[5];
                    retorno.terminal = arreglo[6];
                }
            }

            return retorno;
        }
    }
}

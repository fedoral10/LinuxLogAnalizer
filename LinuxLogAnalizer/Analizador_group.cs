using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxLogAnalizer
{
    class Analizador_group : Analizador
    {

        private string _filename;

        public Analizador_group(string archivo)
        {
            this._filename = archivo;
        }

        public override void insertarEnDB()
        {
            var lista = this.leerArchivo(_filename);
            clsRepo repo = new clsRepo();
            foreach (string linea in lista)
            {
                Dominio.Group group = getGroupLine(linea);
                repo.Insertar<Dominio.Group>(group);
            }
        }

        public Dominio.Group getGroupLine(string linea)
        {
            Dominio.Group retorno = new Dominio.Group();

            string[] arreglo = linea.Split(':');
            retorno.groupName = arreglo[0];
            retorno.password = arreglo[1];
            retorno.gid = int.Parse(arreglo[2]);
            retorno.userList = arreglo[3];

            return retorno;
        }
    }
}

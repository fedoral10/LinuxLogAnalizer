using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxLogAnalizer
{
    class Analizador_shadow : Analizador
    {
        private string _filename;

        public Analizador_shadow(string archivo)
        {
            this._filename = archivo;
        }

        public override void insertarEnDB()
        {
            var lista = this.leerArchivo(_filename);
            clsRepo repo = new clsRepo();
            foreach (string linea in lista)
            {
                Dominio.Shadow shadow = getShadowLine(linea);
                repo.Insertar<Dominio.Shadow>(shadow);
            }
        }

        public Dominio.Shadow getShadowLine(string line)
        {
            Dominio.Shadow retorno = new Dominio.Shadow();

            string[] arreglo = line.Split(':');
            retorno.revision = commons.Revision_Actual;
            retorno.usuario = arreglo[0];
            retorno.password = arreglo[1];
            retorno.lastPasswordChanged = string.IsNullOrEmpty(arreglo[2])?0: int.Parse(arreglo[2]);
            retorno.minimo = string.IsNullOrEmpty(arreglo[3])?0:int.Parse(arreglo[3]);
            retorno.maximo = string.IsNullOrEmpty(arreglo[4])?0:int.Parse(arreglo[4]);
            retorno.warning = string.IsNullOrEmpty(arreglo[5])?0:int.Parse(arreglo[5]);
            retorno.inactive = string.IsNullOrEmpty(arreglo[6])?0:int.Parse(arreglo[6]);
            retorno.expire = string.IsNullOrEmpty(arreglo[7])?0:int.Parse(arreglo[7]);
            retorno.reservado = string.IsNullOrEmpty(arreglo[8])?0:int.Parse(arreglo[8]);

            return retorno;
        }
    }
}

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
            retorno.usuario = arreglo[0];
            retorno.password = arreglo[1];
            retorno.lastPasswordChanged = int.Parse(arreglo[2]);
            retorno.minimo = int.Parse(arreglo[3]);
            retorno.maximo = int.Parse(arreglo[4]);
            retorno.warning = int.Parse(arreglo[5]);
            retorno.inactive = int.Parse(arreglo[6]);
            retorno.expire = int.Parse(arreglo[7]);
            retorno.reservado = int.Parse(arreglo[8]);

            return retorno;
        }
    }
}

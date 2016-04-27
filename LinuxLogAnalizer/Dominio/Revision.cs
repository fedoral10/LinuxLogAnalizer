using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxLogAnalizer.Dominio
{
    public class Revision
    {
        public virtual long idRevision { get; set; }
        public virtual string descripcion { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Revision objAsPart = obj as Revision;

            if (objAsPart == null)
                return false;
            
            if (objAsPart.idRevision == this.idRevision)
                return true;
            else
                return false;

        }
        public override int GetHashCode()
        {
            int hash = 1;
            hash = hash + this.idRevision.GetHashCode();

            return hash;
        }
        public override string ToString()
        {
            return this.descripcion;
        }
    }
}

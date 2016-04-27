using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxLogAnalizer.Dominio
{
    public class Ip
    {
        public virtual long idIp { get; set; }

        public virtual string ip { get; set; }

        public virtual string descripcion { get; set; }

        public virtual string samaccountname { get; set; }
    }
}

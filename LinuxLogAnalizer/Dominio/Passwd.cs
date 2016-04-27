using System;
using System.Text;
using System.Collections.Generic;


namespace LinuxLogAnalizer.Dominio {
    
    public class Passwd {
        public virtual long idPasswd { get; set; }
        public virtual string usuario { get; set; }
        public virtual int? gid { get; set; }
        public virtual string home { get; set; }
        public virtual string descripcion { get; set; }
        public virtual string password { get; set; }
        public virtual string terminal { get; set; }
        public virtual int? uid { get; set; }
        public virtual Revision revision { get; set; }
    }
}

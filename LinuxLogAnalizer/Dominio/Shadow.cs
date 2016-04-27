using System;
using System.Text;
using System.Collections.Generic;


namespace LinuxLogAnalizer.Dominio {
    
    public class Shadow {
        public virtual long idShadow { get; set; }
        public virtual string usuario { get; set; }
        public virtual int? reservado { get; set; }
        public virtual int? inactive { get; set; }
        public virtual string password { get; set; }
        public virtual int? lastPasswordChanged { get; set; }
        public virtual int? maximo { get; set; }
        public virtual int? warning { get; set; }
        public virtual int? minimo { get; set; }
        public virtual int? expire { get; set; }
        public virtual Revision revision { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace LinuxLogAnalizer.Dominio {
    
    public class Secure {
        public virtual long idSecure { get; set; }
        public virtual DateTime fechaHoraValue { get; set; }
        public virtual string procesoId { get; set; }
        public virtual string fechaHora { get; set; }
        public virtual string hostname { get; set; }
        public virtual string mensaje { get; set; }
        public virtual Revision revision { get; set; }
    }
}

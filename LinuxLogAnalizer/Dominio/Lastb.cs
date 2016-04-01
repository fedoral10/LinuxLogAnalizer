using System;
using System.Text;
using System.Collections.Generic;


namespace LinuxLogAnalizer.Dominio {
    
    public class Lastb {
        public virtual long idLastb { get; set; }
        public virtual DateTime fechaValue { get; set; }
        public virtual string ip { get; set; }
        public virtual string username { get; set; }
        public virtual string servicio { get; set; }
        public virtual string tiempoConexion { get; set; }
        public virtual string fecha { get; set; }
    }
}

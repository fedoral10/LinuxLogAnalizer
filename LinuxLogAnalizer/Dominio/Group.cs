using System;
using System.Text;
using System.Collections.Generic;


namespace LinuxLogAnalizer.Dominio {
    
    public class Group {
        public virtual long idGroup { get; set; }
        public virtual int? gid { get; set; }
        public virtual string groupName { get; set; }
        public virtual string password { get; set; }
        public virtual string userList { get; set; }
    }
}

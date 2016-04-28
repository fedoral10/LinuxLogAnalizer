using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinuxLogAnalizer.Config
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("Configuracion")]
    public class ConfigGlobal
    {
        [System.Xml.Serialization.XmlElement("usuario")]
        public string usuario { get; set; }

        public string GetPassword()
        {
            if (!string.IsNullOrEmpty(this.password))
                return StringCipher.Decrypt(this.password, "FedoraI386");
            else
                return null;
        }
        public void SetPassword(string pw)
        {
            this.password = StringCipher.Encrypt(pw, "FedoraI386");
        }

        [System.Xml.Serialization.XmlElement("password")]
        public virtual string password { get; set; }

        [System.Xml.Serialization.XmlElement("host")]
        public string host { get; set; }

        [System.Xml.Serialization.XmlElement("DB")]
        public string db { get; set; }

        [System.Xml.Serialization.XmlElement("puerto")]
        public string puerto { get; set; }

        [XmlArray("Reportes")]
        [XmlArrayItem("Reporte", typeof(Reporte))]
        public Reporte[] Reportes { get; set; } 
    }
}

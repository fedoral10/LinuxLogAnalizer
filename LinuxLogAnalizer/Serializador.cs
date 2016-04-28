using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinuxLogAnalizer
{

    class Serializador
    {
        public static void serializar<T>(T Objeto, string archivo) where T : class
        {

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var subReq = Objeto;
            using (StreamWriter writer = new StreamWriter(@archivo))
            {
                serializer.Serialize(writer.BaseStream, subReq);
            }

        }

        public static T deserializar<T>(string archivo) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            T config;
            using (StreamReader reader = new StreamReader(archivo))
            {
                config = (T)serializer.Deserialize(reader);
                //reader.Close();
            }

            return config;
        }
    }
}

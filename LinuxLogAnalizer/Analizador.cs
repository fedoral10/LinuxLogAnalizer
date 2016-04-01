using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LinuxLogAnalizer
{
    abstract class Analizador
    {
        public abstract void insertarEnDB();
        public virtual string[] leerArchivo(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}

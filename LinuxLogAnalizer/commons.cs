using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LinuxLogAnalizer
{
    class commons
    {
        private static void read(string path)
        {
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(f, Encoding.UTF8, false, 10240);
            string linea = "";
            int x = 0;
            while ((linea = reader.ReadLine()) != null)
            {
                if (x == 1)
                    Console.WriteLine(linea);
                x++;
                /*Console.WriteLine(x);
                x++;
                if (x == 100000)
                    break;*/
            }
        }
        private static void read1(string path)
        {
            var lista = File.ReadLines(path);
            int x = 0;
            foreach (string linea in lista)
            {

                if (x == 1)
                    Console.WriteLine(linea);
                x++;
                //break;
                /*Console.WriteLine(x);
                x++;
                if (x == 100000)
                    break;
                 * */
            }
        }

        public static List<string> leerArchiv(string filename)
        {
            return File.ReadAllLines(filename).OfType<string>().ToList<string>();
        }
        public static string[] leerArchivoArray(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}

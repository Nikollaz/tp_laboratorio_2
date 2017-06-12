using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos) 
        {
            StreamWriter str = new StreamWriter(archivo, false);
            XmlSerializer xml = new XmlSerializer(typeof(T));

            try
            {
                xml.Serialize(str, datos);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                str.Close();
            }

            return true; 
        }

        public bool leer(string archivo, out T datos) { datos = default(T); return true; }
    }
}

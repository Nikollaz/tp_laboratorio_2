using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto
    {
        public static bool guardar(string archivo, string datos) 
        {
            StreamWriter str = new StreamWriter(archivo, false);

            try
            {
                str.Write(datos);
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
                return false;
            }
            finally
            {
                str.Close();
            }

            return true;
        }

        public static bool leer(string archivo, out string datos) 
        {
            StreamReader str = new StreamReader(archivo);
            datos = str.ReadToEnd();
            str.Close();

            return true; 
        }              
    }
}

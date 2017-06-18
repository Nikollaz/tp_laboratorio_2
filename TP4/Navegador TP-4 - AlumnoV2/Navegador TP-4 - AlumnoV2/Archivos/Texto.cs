using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        /// <summary>
        /// Guarda los datos pasados por parametro en el archivo con nombre del atributo "_archivo"
        /// </summary>
        /// <param name="datos">Datos a guardar</param>
        /// <returns></returns>
        public bool guardar(String datos)
        {
            StreamWriter str = new StreamWriter(this._archivo, true);

            try
            {
                str.WriteLine(datos);
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

        /// <summary>
        /// Agrega a la lista "datos" pasada por parametro, los datos ubicados en el archivo con nombre del atributo "_archivo"
        /// </summary>
        /// <param name="datos">Lista en la cual se guardaran los datos</param>
        /// <returns></returns>
        public bool leer(out List<String> datos)
        {
            var archivo = File.ReadAllLines(this._archivo);
            datos = new List<String>(archivo);

            return true; 
        }
    }
}

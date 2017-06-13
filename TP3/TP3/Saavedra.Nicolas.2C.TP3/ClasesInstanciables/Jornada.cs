using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace ClasesInstanciables
{
    /// <summary>
    /// . Atributos Profesor, Clase y Alumnos que toman dicha clase.
    /// . Se inicializará la lista de alumnos en el constructor por defecto.
    /// . Una Jornada será igual a un Alumno si el mismo participa de la clase.
    /// . Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
    /// . ToString mostrará todos los datos de la Jornada.
    /// . Guardar de clase guardará los datos de la Jornada en un archivo de texto.
    /// . Leer de clase retornará los datos de la Jornada como texto.
    /// </summary>
    public class Jornada : Texto
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        
        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }     

        public Profesor Instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }

        /// <summary>
        /// Guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada) 
        {
            return Texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());  
        }

        private Jornada() 
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this() 
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public string Leer() 
        {
            string a = "";
            Texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out a);
            
            return a; 
        }

        public static bool operator !=(Jornada j, Alumno a) 
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a) 
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j; 
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a) 
        {
            foreach (Alumno alumno in j._alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false; 
        }

        /// <summary>
        /// Mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder("");            
            str.AppendLine("CLASE DE " + this.Clase);
            str.AppendLine(this.Instructor.ToString());
            str.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                str.AppendLine(alumno.ToString());
            }
            str.AppendLine("<--------------------------------------------->\n");
            return str.ToString();
        }
        
    }
}

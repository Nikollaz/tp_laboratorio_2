using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    /// <summary>
    /// . Atributos Alumnos (lista de inscriptos), Profesores (lista de quienes pueden dar clases) y Jornadas.
    /// . Se accederá a una Jornada específica a través de un indexador.
    /// . Un Universidad será igual a un Alumno si el mismo está inscripto en él.
    /// . Un Universidad será igual a un Profesor si el mismo está dando clases en él.
    /// . La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
    /// . El distinto retornará el primer Profesor que no pueda dar la clase.
    /// . Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
    ///   un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman 
    ///   (todos los que coincidan en su campo ClaseQueToma).
    /// . Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
    ///   Sino, lanzará la Excepción SinProfesorException.    
    /// . MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.
    /// . Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
    /// 
    /// . Leer de clase retornará un Universidad con todos los datos previamente serializados.
    /// </summary>
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        
        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { jornada = value; }
        }

	    public List<Alumno> Alumnos
	    {
		    get { return alumnos;}
		    set { alumnos = value;}
	    }

        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { jornada[i] = value; }        
        }

        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim) 
        {
            //Universidad.xml
            
            StreamWriter str = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", false);
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            try
            {
                xml.Serialize(str, gim);
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

        /// <summary>
        /// Leer de clase retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            StreamReader str = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            Universidad universidad = (Universidad)xml.Deserialize(str);
            
            str.Close();

            return universidad;
        }

        /// <summary>
        /// MostrarDatos será privado y de clase.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim) 
        {
            StringBuilder str = new StringBuilder("");
            str.AppendLine("JORNADA: ");
            foreach (Jornada jornada in gim.Jornadas)
            {
                str.Append(jornada.ToString());
            }
            return str.ToString();
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a) 
        { 
            return !(g==a); 
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase) 
        { 
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }

            return null;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i) 
        { 
            return !(g == i); 
        }

        /// <summary>
        /// . Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        ///   Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a) 
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return g; 
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman 
        /// (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase) 
        { 
            Profesor prof = (g == clase);
            List<Alumno> alumnos = new List<Alumno>();
            Jornada jornada = null;

            if (!(Object.Equals(prof,null)))
            {
                jornada = new Jornada(clase, prof);
            }
            else
            {
                throw new SinProfesorException();
            }
                
            if (!(Object.Equals(jornada, null)))
            {
                foreach (Alumno al in g.Alumnos)
                {
                    if (al == clase)
                        jornada = jornada + al;
                }
                
                g.Jornadas.Add(jornada);
            }           

            return g; 
        }

        /// <summary>
        /// . Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        ///   Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i) 
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            else
            {
                throw new SinProfesorException();
            }

            return g; 
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a) 
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false; 
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase) 
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }
            return null;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i) 
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    return true;
            }
            return false; 
        }

        /// <summary>
        /// Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();       
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            SPD,
            Legislacion
        }
    }
}

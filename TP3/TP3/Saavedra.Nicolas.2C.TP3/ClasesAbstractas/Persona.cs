using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    /// <summary>
    /// . Abstracta, con los atributos Nombre, Apellido, Nacionalidad y DNI.
    /// . Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. Caso contrario, 
    ///   se lanzará la excepción DniInvalidoException.
    /// . Sólo se realizarán las validaciones dentro de las propiedades.
    /// . Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
    /// . ToString retornará los datos de la Persona.
    /// </summary>
    public abstract class Persona
    {
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;
        
        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    _apellido = value;
            }
        }

        public int DNI
        {
            get { return _dni; }
            set 
            { 
                _dni = ValidarDni(Nacionalidad, value); 
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set 
            {
                if(ValidarNombreApellido(value)!=null)
                    _nombre = value; 
            }
        }        
                        
        public string StringToDNI 
        { 
            set 
            {
                _dni = ValidarDni(Nacionalidad, value);
            } 
        }

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this() 
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad) 
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad) 
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Retornará los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder("");
            str.Append("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\n");
            str.Append("NACIONALIDAD: " + this.Nacionalidad.ToString()+ "\n\n");
            return str.ToString();
        }

        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. 
        /// Caso contrario, se lanzará la excepción DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato) 
        {
            try
            {
                if (!(nacionalidad.Equals(ENacionalidad.Argentino)) && (dato < 1 || dato > 89999999))
                {
                    throw new DniInvalidoException();
                }
            }
            catch (DniInvalidoException e)
            {
                Console.WriteLine("La nacionalidad no se condice con el numero de DNI");
                return -1;
            }

            //if (!(nacionalidad.Equals(ENacionalidad.Argentino)) && (dato < 1 || dato > 89999999))
            //{
            //    throw new DniInvalidoException();
            //}
           
            return dato; 
        }

        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Argentino entre 1 y 89999999. Caso contrario, se lanzará la excepción DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            return ValidarDni(nacionalidad, int.Parse(dato)); 
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato) 
        {
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
                return dato;
            else
                return null; 
        }

        /// <summary>
        /// Enum que contiene las posibles nacionalidades de las personas
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
                
    }
}

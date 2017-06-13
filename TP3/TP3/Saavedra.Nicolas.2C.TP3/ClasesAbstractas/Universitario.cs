using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// . Abstracta, con el atributo Legajo.
    /// . Método protegido y virtual MostrarDatos retornará todos los datos del Universitario.
    /// . Método protegido y abstracto ParticiparEnClase.
    /// . Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
    /// </summary>
    public abstract class Universitario : Persona
    {
        protected int legajo;

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="obj">Elemento a comparar</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (this == ((Universitario)obj));
        }

        /// <summary>
        /// Retornará todos los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos() 
        {
            StringBuilder str = new StringBuilder("");
            str.AppendLine(base.ToString());
            str.AppendLine("LEGAJO NUMERO: " + this.legajo);
            str.AppendLine("");
            return str.ToString();
        }

        public static bool operator !=(Universitario pg1, Universitario pg2) 
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2) 
        {
            return ((pg1 is Universitario && pg2 is Universitario) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        protected abstract string ParticiparEnClase();

        public Universitario() : base() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad) 
        {
            this.legajo = legajo;
        }
            
    }
}

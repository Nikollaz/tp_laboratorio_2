using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    /// <summary>
    /// . Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo EEstadoCuenta.
    /// . Sobreescribirá el método MostrarDatos con todos los datos del alumno.
    /// . ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
    /// . ToString hará públicos los datos del Alumno.
    /// . Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
    /// . Un Alumno será distinto a un EClase sólo si no toma esa clase.
    /// </summary>
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno() : base() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma) 
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder("");
            str.Append(base.MostrarDatos());
            str.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            str.Append(this.ParticiparEnClase());
            return str.ToString();
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase) 
        { 
            return !(a._claseQueToma.Equals(clase)); 
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase) 
        { 
            return (a._claseQueToma.Equals(clase) && !(a._estadoCuenta.Equals(EEstadoCuenta.Deudor))); 
        }

        /// <summary>
        /// Retornará la cadena "TOMA CLASES DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma + "\n";
        }

        /// <summary>
        /// ToString hará públicos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public enum EEstadoCuenta
        {
            Becado,
            Deudor,
            AlDia
        }
    }
}

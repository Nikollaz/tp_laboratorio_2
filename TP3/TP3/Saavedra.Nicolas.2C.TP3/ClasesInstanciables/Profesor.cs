using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    /// <summary>
    /// . Atributos ClasesDelDia del tipo Cola y random del tipo Random y estático.
    /// . Sobrescribir el método MostrarDatos con todos los datos del alumno.
    /// . ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
    /// . ToString hará públicos los datos del Profesor.
    /// . Se inicializará a Random sólo en un constructor.
    /// . En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos 
    ///   clases al azar al Profesor mediante el método randomClases. Las dos clases pueden o no ser la misma.
    /// . Un Profesor será igual a un EClase si da esa clase.
    /// </summary>
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor() 
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this() 
        {
            this.legajo = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Se asignarán dos clases al azar al Profesor mediante el método randomClases. Las dos clases pueden o no ser la misma.
        /// </summary>
        private void _randomClases()
        {
            Array values = Enum.GetValues(typeof(Universidad.EClases));
            for (int i = 0; i < 2; i++)
            {
                Universidad.EClases randomBar = (Universidad.EClases)values.GetValue(_random.Next(values.Length));
                this._clasesDelDia.Enqueue(randomBar);
            }
        }

        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder("");
            str.Append(base.MostrarDatos());
            str.Append(this.ParticiparEnClase());
            return str.ToString();
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases cl in i._clasesDelDia)
            {
                if (cl.Equals(clase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder("");
            str.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this._clasesDelDia)
            {
                str.AppendLine(clase.ToString());
            }
            return str.ToString();
        }

        /// <summary>
        /// Hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}

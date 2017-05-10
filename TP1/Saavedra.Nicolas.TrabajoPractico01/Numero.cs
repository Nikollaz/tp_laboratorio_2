using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saavedra.Nicolas.TrabajoPractico01
{
    /// <summary>
    /// Clase que tiene por propósito de validar y contener los operandos.
    /// </summary>
    class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(String numero)
        {
            setNumero(numero);
        }

        /// <summary>
        /// Getter del atributo 'numero'
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Setter del atributo 'numero'
        /// </summary>
        /// <param name="numero">String con valor a ser validado y luego seteado</param>
        private void setNumero(String numero) 
        {
            this.numero = validarNumero(numero);
        }

        /// <summary>
        /// Valida que se trate de un double válido, caso contrario retornará 0.
        /// </summary>
        /// <param name="numeroString">String a ser validado</param>
        /// <returns>String parseado a double en caso de ser exitoso, o 0 en caso de fallar</returns>
        private double validarNumero(String numeroString)
        {
            if (!(Double.TryParse(numeroString, out this.numero)))
            {
                return 0;
            }
            return this.numero;
        }
    }
}

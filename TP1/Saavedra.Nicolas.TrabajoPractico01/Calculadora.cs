using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saavedra.Nicolas.TrabajoPractico01
{
    /// <summary>
    /// Clase que tiene por propósito operar matemáticamente dos objetos del tipo Numero 
    /// según se le indique.
    /// </summary>
    class Calculadora
    {
        /// <summary>
        /// Recibe dos objetos del tipo Numero llamador numero1 y numero2, y un String llamado 
        /// operador. Su valor de retorno será del tipo double. Si no puede operar
        /// (división por 0), retornará 0.
        /// </summary>
        /// <param name="numero1">Primer numero del calculo</param>
        /// <param name="numero2">Segundo numero del calculo</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double a = 0;
            string auxOperador = validarOperador(operador);
            switch (auxOperador)
            {
                case "+":
                    a = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    a = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    a = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        a = numero1.getNumero() / numero2.getNumero();
                    }
                    break;
            }
            return a;
        }

        /// <summary>
        /// Valida que el operador sea un caracter válido, caso contrario retornará “+”.
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Operador validado o "+" en caso de haber sido un operador invalido</returns>
        public static string validarOperador(string operador)
        {
            if (!operador.Equals("+") && !operador.Equals("-") && !operador.Equals("*") && !operador.Equals("/"))
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }

        /// <summary>
        /// Recibe un string por parametro y lo convierte en un string vacio
        /// </summary>
        /// <param name="numero">Numero a vaciar</param>
        /// <returns>Nuevo vaciado</returns>
        public static string limpiar(string numero)
        {
            numero = "";
            return numero;
        }
    }
}

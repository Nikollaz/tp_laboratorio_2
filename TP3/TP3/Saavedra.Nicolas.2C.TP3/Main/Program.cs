using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace Main
{
    /// <summary>
    /// Condiciones de corrección y aprobación:
    /// 1. Qué se respeten todas las consignas dadas.
    /// 2. Qué todas las Clases, Métodos, Atributos, Propiedades, etc. sean nombrados exactamente como fue pedido en el enunciado.
    /// 3. Qué NO modifique la función Main dada.
    /// 4. Qué el proyecto no contenga errores de ningún tipo.
    /// 5. Qué el código compile y se ejecute de manera correcta.
    /// 6. Qué la salida por pantalla con el formato de la entregada en este mismo documento.
    /// 7. Se deberá reutilizar código cada vez que se pueda, aunque no esté explicitado en el contenido del texto.
    /// 8. Se deberá documentar el código según las reglas de estilo de la cátedra.
    /// 9. Test Unitarios:
    ///     a. Generar al menos dos test unitario que validen Excepciones
    ///     b. Generar al menos uno que valide un valor numérico
    ///     c. Generar al menos uno que valide que no haya valores nulos en algún atributo de las clases dadas.
    /// 10. Todas las excepciones deberán tener mensajes propios.
    /// 11. Qué pase, sin modificaciones de código, los Test Unitarios que genere quien esté a cargo de la corrección del examen (para eso se deberá cumplir con todo lo anteriormente planteado).
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            gim += a1;
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                gim += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            gim += a4;
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            gim += a5;
            Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            gim += a6;
            Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            gim += a7;
            Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            gim += a8;
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i1;
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i2;
            try
            {
                gim += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(gim.ToString());
            Console.ReadKey();
            Console.Clear();
            try
            {
                Universidad.Guardar(gim);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                int jornada = 0;
                Jornada.Guardar(gim[jornada]);
                Console.WriteLine("Archivo de Jornada {0} guardado.", jornada);
                //Console.WriteLine(Jornada.Leer()); 
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
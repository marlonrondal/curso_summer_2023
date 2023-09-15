using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Empleado juan = new Empleado("Juan");
            //Console.WriteLine(juan.ToString());

            Administrador maria = new Administrador("Maria", true);

            juan.Jefe = maria; //El jefe de juan es maria;

            Empleado jose = new Trabajador("jose", "tarde");
            jose.Jefe = maria;

            Empleado luis = new Externo("Luis", new Empresa { Nombre = "ACME", Telefono = 94398348 });

            var lista = new List<Empleado>()
            {
                juan, //Casting: convertir de un tipo a otro. Esto es una conversión temporal
                jose,
                maria,
                new Trabajador("Luis", "Mañana"),
                luis

            };

            //Calcular vacaciones para aquellos empleados con nombre que empieza dsde j

            foreach (var empleado in lista)
            {

                if (empleado.Nombre.ToLower().StartsWith('j'))
                {
                    empleado.CalculoVacaciones();
                    Console.WriteLine(empleado.ToString());
                }

            }

            //En formato sql: SELECT * FROM empleados WHERE empleados.Nombre.StartsWith("J");

            IEnumerable<Empleado> listaempleadosJ = from empleado in lista
                                                    where empleado.Nombre.StartsWith("J")
                                                    || empleado.Nombre.StartsWith("j")
                                                    orderby empleado.Nombre
                                                    select empleado;

            Console.WriteLine();
            foreach (var empleado in listaempleadosJ)
            {

                empleado.CalculoVacaciones();
                Console.WriteLine(empleado.ToString());
            }
            Console.WriteLine();

            try
            {
                //maria tiene plaza de parking? si tiene mostrar


                if (maria.TieneParking) //no va a pàsar
                {
                    Console.WriteLine(maria.plazaParking());

                }
            }

            catch (ErrorBaseDatosExcepcion ex)
            {

                Console.WriteLine(ex.ToString() + ex.FechaHoraExcepcion.ToString()); //Con tu string saco un texto predeterminado. También imprimo el tiempo

            }

            catch (Exception ex)
            {//Controlar si se ha producido un error de base de datos. Mostrar mensaje de error




            } //El mas general abajo

            //Crear una excepcion personalizada ErrorBaseDatos que almacena
            //la fecha y hora de la exc`pcion con mensaje personalizado. La excepcion ocurre al pedir
            //plaza de parking de administrativo

            // Identificar mediante reflexion los diferentes tipos de empleados de modo que si 
            //   a) El trabajador muestra el turno
            //   b) Es admin y tiene plaza de parkin mostrar plaza de parkin
            //   c) Si es externo mostrar nombre de empresa de la que viene

            /* Esto era el ejercicio de ayer: :

            Empleado juan = new Empleado("Juan");
            Administrador jose = new Administrador("Jose");
            Trabajador laura = new Trabajador("Laura");

            Console.WriteLine(juan.ToString());
            Console.WriteLine(jose.ToString());
            Console.WriteLine(laura.ToString());


            */





        }
    }
}
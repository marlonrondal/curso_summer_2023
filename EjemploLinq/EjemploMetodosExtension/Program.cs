using Extensiones;
namespace EjemploMetodosExtension
{


    internal class Program
    {
        static void Main(string[] args)
        {
            string juan = "JuAN lOpEz".ConvertirCadena();

            string luis = "lUiS MaRTinEz".ConvertirCadena();


            var saludo = "Hola Mundo !!!!!";

            var convertir = saludo.ConvertirCadena();


            // Mostrar año de la fecha

            DateTime fecha = DateTime.Now;
            var año = fecha.ObtenerAño();


            // Agregar metodo de extension para comparar dos enteros


            int a = 1;
            int b = 2;


            //bool esmayorAB = a > b;

            if (a.EsMayorQue(b))
            {
                Console.WriteLine("Es Mayor");
            }
            else
            {
                Console.WriteLine("Es Menor");
            }

            // Obtener el primer elemento de la lista

            var lista = new List<int>() { 1, 2, 3, 4, 5, 6 };

            var primero = lista.Primero();







        }
    }

}
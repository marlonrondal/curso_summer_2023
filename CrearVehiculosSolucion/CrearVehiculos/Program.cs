using static CrearVehiculos.Entidades.Vehiculo;

namespace CrearVehiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
           vehiculoSimple vehiculo1 = new vehiculoSimple(2022, "Rojo");
            Console.WriteLine("Vehiculo 1:");
            Console.WriteLine($"Año de compra:{vehiculo1.Anio}");
            Console.WriteLine($"Color:{vehiculo1.Color}");
            vehiculoMarcaModelo vehiculo2 = new vehiculoMarcaModelo("Seat", "Leon");
            
            Console.WriteLine("Vehiculo 2:");
            Console.WriteLine($"Marca:{vehiculo2.Marca}");
            Console.WriteLine($"Modelo:{vehiculo2.Modelo}");
            vehiculoCompleto vehiculo3 = new vehiculoCompleto(2023, "Negro", "Ford", "Focus");
            Console.WriteLine("Vehiculo 3:");
            Console.WriteLine($"Año de compra:{vehiculo3.Anio}");
            Console.WriteLine($"Color:{vehiculo3.Color}");
            Console.WriteLine($"Marca:{vehiculo3.Marca}");
            Console.WriteLine($"Modelo:{vehiculo3.Modelo}");


        }
    }
}
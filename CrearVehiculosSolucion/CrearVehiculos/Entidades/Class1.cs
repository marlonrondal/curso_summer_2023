using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearVehiculos.Entidades
{
    internal class Class1
    {
    }

    public class Vehiculo
    {
        public int Anio { get; set; }
        public string Color { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Vehiculo(int anioCompra, string color, string marca, string modelo)
        {
            Anio = anioCompra;
            Color = color;
            Marca = marca;
            Modelo = modelo;


        }

        public class vehiculoSimple : Vehiculo
        {
            public vehiculoSimple(int anioCompra, string color) : 

                base(anioCompra, color, "", "") { }
        }

        public class vehiculoMarcaModelo : Vehiculo
        {
            public vehiculoMarcaModelo(string marca, string Modelo) : base
                (0,"",marca, Modelo) { }
        }

        public class vehiculoCompleto : Vehiculo
        {
            public vehiculoCompleto(int anioCompra, string color, string marca, string modelo) :
            base(anioCompra, color, marca, modelo)
        { }
        }


    
    }
}

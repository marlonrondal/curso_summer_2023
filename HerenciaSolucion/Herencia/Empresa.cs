using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    public class Empresa
    {
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public Empresa() { }
        public Empresa(string nombre, int telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }

    }
}

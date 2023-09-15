using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    public partial class Empleado
    {
        public string? Tlf { get; set; }

        public Empleado Jefe { get; set; }

        
    }
}

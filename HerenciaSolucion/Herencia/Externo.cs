using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    public class Externo : Empleado
    {

        public Empresa Empresa { get; set; }
        public Externo(string nombre, Empresa empresa) : base(nombre)
        {
            Empresa = empresa;
        }

        public override string ToString()
        {
            return $"[ Empleado.Nombre: {Nombre}" +
                $" Dias Vacaciones: {diasVacaciones}" +
                $" Tipo: Externo ]";
        }



    }
}

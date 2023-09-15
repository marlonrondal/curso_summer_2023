using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    public partial class Empleado
    {
        public partial class Empleado
        {
            public String? Telefono { get; set; }


            protected double diasVacaciones; //No se puede conocer desde fuera. Si fuera privated, no se vería desde la herencia. Protected es para que no se vea desde fuera

            public override string ToString()
            {
                return $"[ Empleado.Nombre: {Nombre}" +
                    $" Dias Vacaciones: {diasVacaciones}" +
                    $" Tipo: Empleado ]";

            }

            public virtual void CalculoVacaciones() //Virtual porque puede ocurrir que en padre no defina nada
            {
                diasVacaciones += 10;
            }
        }
    }
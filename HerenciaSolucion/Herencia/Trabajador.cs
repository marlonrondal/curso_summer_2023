using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    public class Trabajador : Empleado
    {
        public Trabajador(string nombre, string turno) : base(nombre)
        {
            Turno = turno;
        }

        public string Turno { get; }

        public override string ToString()
        {
            return $"[ Empleado.Nombre: {Nombre}" +
                $" Dias Vacaciones: {diasVacaciones}" +
                $" Tipo: Trabajador ]";
        }

        public override void CalculoVacaciones() //Virtual porque puede ocurrir que en padre no defina nada
        {
            base.CalculoVacaciones(); //Antes llamamos al padre para sumar 10. 
            diasVacaciones += 15;
        }
    }
}
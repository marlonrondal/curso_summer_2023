using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    public class Administrador : Empleado
    {
        public Administrador(string nombre, bool tieneParking) : base(nombre)
        {
            TieneParking = tieneParking;

        }

        public bool TieneParking { get; }


        public override string ToString()
        {
            return $"[ Empleado.Nombre: {Nombre}" +
                $" Dias Vacaciones: {diasVacaciones}" +
                $" Tipo: Administrativo ]";
        }

        public String plazaParking()
        {
            //TODO: Conectar a BBDD

            throw new ErrorBaseDatosExcepcion("Error al conectar BBDD", DateTime.Now);//Se para todo
            return TieneParking ? "Plaza A-1" : "No tiene Plaza";

        }
        public virtual void CalculoVacaciones() //Virtual porque puede ocurrir que en padre no defina nada
        {
            diasVacaciones += 9; //no lllamamos a base!!!!
        }


    }

}
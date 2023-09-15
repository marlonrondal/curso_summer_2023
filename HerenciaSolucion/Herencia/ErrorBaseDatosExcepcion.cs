using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    internal class ErrorBaseDatosExcepcion : Exception
    {

        public ErrorBaseDatosExcepcion(string mensaje, DateTime fechaHoraExcepcion)
            : base(mensaje)
            {
                FechaHoraExcepcion = fechaHoraExcepcion;
            }
    }
}

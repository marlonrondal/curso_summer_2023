using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegado.Medios
{
    public class ReproducirCds
    {

        public bool ProbarCd()
        {
            Console.WriteLine("Por favor, ponga el cd en el reproductor");
            Console.WriteLine("Pulsa el boton de reproducir");
            Console.WriteLine("Indique si ha escuchado algo");


            var result = Console.ReadLine();

            //Equivale a if (result == "S")/else
            return result == "S";
        }

        
        public string ObtenerCancionesCd(string codigoBarras)
        {

           

                return "Lista canciones CD estan en la contraportada :"+ codigoBarras;

        }
    }

}

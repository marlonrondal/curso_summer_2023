using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegado.Medios
{

    public class Tocadiscos
    {


        // bool no tiene parametros()
        public bool ProbarTocadisco()
        {
            Console.WriteLine("Por favor, ponga el cd en el reproductor");
            Console.WriteLine("Pulsa el boton de reproducir");
            Console.WriteLine("Indique si ha escuchado algo");

            var result = Console.ReadLine();

            //Equivale a if (result == "S")/else
            return result == "S";
        }

        public string ObtenerCancionesTocaDisco(string codigoBarras)
        {
            //buscar en BBDD codigobarras
            //devolver resultados
            return "Lista canciones del Vinilo estan en la contraportada :"+ codigoBarras;
        
        }
    }
}

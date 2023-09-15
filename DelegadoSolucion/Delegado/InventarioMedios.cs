using Delegado.Medios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegado
{
    public class InventarioMedios
    {
        //



        //declarar el delegado probar medios
        public delegate bool ProbarMediosDelegado();
        //delegado para mostrr info medio
        public delegate string InfoMedioDelegado(String id);

        public void ResultadosInfoMedios(InfoMedioDelegado infoMedioDelegado, string id)
        {
            var resultadoInfo = infoMedioDelegado(id);

            Console.WriteLine(resultadoInfo);


        
        }


        public void ResultadoProbarMedios(ProbarMediosDelegado probarMedioDelegado) {

            //1 recibir el medio a probar
            //2 probar medio
            //3 si el medio se ha podido reproducir inidcar el archivo



            var resultadoPrueba = probarMedioDelegado();

            if (resultadoPrueba)
            {
                Console.WriteLine("El medio funciona, " + "hay que agregar al inventario");
            }
            else
            {
                Console.WriteLine("El medio no funciona, decirlo");
            }





            /*var tipo = medio.GetType().FullName;
            if (tipo == "Tocadisco")
                {
                var obj = (Tocadiscos)medio;
                if (obj.ProbarTocadisco())
                {
                    Console.WriteLine("Intrucciones para almacenar vinilo");
                }
            }*/



        }
    }
}

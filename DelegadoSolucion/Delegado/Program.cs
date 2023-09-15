
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Delegado.Medios;

using static Delegado.Medios.ReproducirCds;
using static Delegado.InventarioMedios;

namespace Delegado
{

    /*hay que crear una aplicacion para 
    el archivo de medios de una biblioteca publica de modo que:
    A- segun el tipo de medio indique al usuario los pasos a dar para
        reproducir ese medio y verificar
        si esta en buen estado para el archivo o
        bien desecharlo asi esta en mal estado
    B- crear una aplicacion que permita
    los pasos a dar independiente del medio.
    Pasar codigo de barra o identificar para localizar el medio en la BBDD
    C- Mostrar el contenido del medio segun el tipo de medio

        Cds- mostrar lista canciones
        Vinilo- mostrar lista de canciones en la contraportada
        Vhs- mostrar informacion de la pelicula

    */
    public class Program
    {
        static void Main(string[] args)
        {
            // Crear Instacias

            var inventarioMedios = new InventarioMedios();

            var tocaDiscos =  new Tocadiscos();

            var videoVhs = new VideoVhs();

            var reproducirCd = new ReproducirCds();

            //2- Crear instancia Delegados guarda metodos
            ProbarMediosDelegado probarDiscosDelegados =
                new ProbarMediosDelegado(tocaDiscos.ProbarTocadisco);

            ProbarMediosDelegado probarVideoVhsDelegados =
                new ProbarMediosDelegado(videoVhs.ProbarVideoVhs);


            //3 Utilizar delegados

            //probar un vinilo

            //inventarioMedios.ResultadoProbarMedios(probarDiscosDelegados);

            // Probar una cinta VHS
            //inventarioMedios.ResultadoProbarMedios(probarVideoVhsDelegados);


            //----------------------------------EJERCICIO C--------------------

            InfoMedioDelegado infoMedioDelegadoTocadisco = new InfoMedioDelegado(tocaDiscos.ObtenerCancionesTocaDisco);
            InfoMedioDelegado infoMedioDelegadoVideoVhs = new InfoMedioDelegado(videoVhs.ObtenerCreditosVideo);
            InfoMedioDelegado infoMedioDelegadoReproducirCds = new InfoMedioDelegado(reproducirCd.ObtenerCancionesCd);

            inventarioMedios.ResultadosInfoMedios(infoMedioDelegadoVideoVhs, "Odisea en el espacio");
            inventarioMedios.ResultadosInfoMedios(infoMedioDelegadoReproducirCds, "Michael jackson");
            inventarioMedios.ResultadosInfoMedios(infoMedioDelegadoTocadisco, "Queen ");

        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploLinq
{
    internal class EjemploBasico
    {
        public EjemploBasico()
        {
        }

        public void Ejecutar()
        {
            string[] niveles = { "Basico", "intermedio", "Avanzado" };
            int nc = niveles.Count();

            //Selecciona Todos los niveles cuya longitud en caracter sea mayor que 6
            //ordenar por niveles
            var listaConsultaForeach = new List<string>();
            foreach (string nivel in niveles)
            {
                if (nivel.Length > 6)
                { 
                    listaConsultaForeach.Add(nivel);
                }
            
            }
            //Sintaxis SQL
            //Selec nivel from niveles where nivel.lenght
            //1.Primero hay una preparación

            var ConsultaLinq = from nivel in niveles 
                                     where nivel.Length > 0
                                     orderby nivel
                                     select nivel;

            //2.Obtener resultados
            List<string> listaResultados = ConsultaLinq.ToList();

            //Sintaxis de Metodos
            //1. Preparacion
            //Func<string, bool> predicado = nivel => nivel.Length > 6;
            // var ConsultaPredicado = niveles.Where(predicado);


            var consultaLinqMetodos = niveles.Where(nivel => nivel.Length > 6)
                .OrderBy(nivel => nivel).Select(nivel => nivel);


            //2.Reultados

            List<string> listaResultadosLinqMetodos = consultaLinqMetodos.ToList();
        }
    }
}

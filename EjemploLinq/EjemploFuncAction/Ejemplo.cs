using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploFuncAction
{
    internal class Ejemplo
    {

        private readonly Action<string> _action;
        public Action<int> AccionProperty { get; set; }


        internal void EjemploAction()
        {
            // Llamar a TestAction pasandole metodo como parametro
            TestAction(AccionMetodo, 1);

            // Llamar a TestAction escribiendo la expresion lambda
            // como parametro entre los dos parentesis

            TestAction((x) =>
            {
                Console.WriteLine($"En el parametro Accion {x}");
            }
               , 1);

            // 1-Crear una variable que almacene la accion
            // 2-Llamar a TestAction pasandole la variable y el valor 1
            Action<int> accion = (y) =>
            {
                Console.WriteLine($"En el parametro Accion {y}");
            };
            TestAction(accion, 1);


            // Lista de Acciones

            List<Action<int>> listaAcciones = new List<Action<int>>();

            listaAcciones.Add(accion);
            listaAcciones.Add(AccionMetodo);

            foreach (var elementoAccion in listaAcciones)
            {

            }

        }

        // Metodo que recibe un Action<int> y un int
        // Dentro ha de llamar al Action pasado como parametro
        public void TestAction(Action<int> accion, int numero)
        {
            accion(numero);
        }

        public void AccionMetodo(int numero)
        {
            Console.WriteLine($"En el metodo Accion {numero}");

        }


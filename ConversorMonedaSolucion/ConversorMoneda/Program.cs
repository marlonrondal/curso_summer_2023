using ConversorMoneda.Entidades;

namespace ConversorMoneda
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al convertidor de monedas");
            Console.WriteLine("Monedas Disponibles DOLAR, EURO, LIBRA ESTERLINA");
            

            const double EuroToDolar = 1.18;
            const double EuroToLibra = 0.85;
             const double DolarToEuro = 0.85;
             const double DolarToLibra = 0.72;
             const double LibraToDolar = 1.38;
             const double LibraToEuro = 1.18;

            Console.WriteLine("¿Que moneda quieres convertir Euro,Dolar,Libra?");
            string monedaOrigen = Console.ReadLine().ToLower();
            Console.WriteLine("¿Que moneda destino quieres convertir Euro,Dolar,Libra?");
            string monedaDestino = Console.ReadLine().ToLower();
            Console.WriteLine("¿Que cantidad quieres convertir?");
            double importe = double.Parse(Console.ReadLine());


            

            
                double resultado = 0;
                switch (monedaOrigen)
                {
                    case "euros":
                        switch (monedaDestino)
                        {
                            case "dolar":
                                resultado = importe * EuroToDolar;
                                break;
                            case "libra:":
                            resultado = importe * EuroToLibra;
                                     break;
                        default: resultado = importe;break;
                        }
                    break;
                    case "dolar":
                        switch (monedaDestino)
                        {
                            case "euros":
                                resultado = importe * DolarToEuro; break;
                            case "libra":
                                resultado = importe * DolarToLibra; break;
                            default: resultado = importe;break;
                        }
                        break; 
                    case "libras":
                        switch (monedaDestino)
                        {
                            case "euros":
                                resultado = importe * LibraToEuro; break;
                            case "dolar":
                                resultado = importe * LibraToDolar; break;
                            default: resultado = importe;break;
                        }
                    break;
                    default : Console.WriteLine("Moneda no reconocida");return;
                }
            
            
            Console.WriteLine($"El resultado es de la conversin es: {resultado},{monedaDestino.ToUpper()}");



        }

        
    }
}

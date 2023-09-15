using Newtonsoft.Json;

namespace ImportarJson
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*string json = @"{
                  'Name': 'Bad Boys',
                  'ReleaseDate': '1995-4-7T00:00:00',
                  'Genres': [
                    'Action',
                    'Comedy'
                  ]
                }";

            Movie m = JsonConvert.DeserializeObject<Movie>(json);

            string name = m.Name;
            Console.WriteLine(name);
            // Bad Boys*/

             string json = File.ReadAllText(@"C:\repos\Summercamp2023\demos\after\02TextFileLines\ImportarJson\Monedas.json");           List <Moneda> monedas = JsonConvert.DeserializeObject< List <Moneda>>(json);            using StreamReader reader = new StreamReader(@"C:\repos\Summercamp2023\demos\after\02TextFileLines\ImportarJson\Monedas.json");            {                            }            foreach (Moneda moneda in monedas)            {                string name = moneda.nombre;                string code = moneda.codigo;                double valor = moneda.valorEnDolares;                Console.WriteLine("\n Moneda: "+ name +" Codigo: " +code+ " valor : "+valor);            }

        }
    }
}
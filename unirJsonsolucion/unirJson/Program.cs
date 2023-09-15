using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // Leer los archivos JSON y convertirlos en diccionarios
        string jsonTextPrefijoNombre = File.ReadAllText(@"/Users/marlon/Desktop/Proyectos/pruebaJsonSolucion/pruebaJson/file1.json");
        string jsonTextPrefijoValor = File.ReadAllText(@"/Users/marlon/Desktop/Proyectos/pruebaJsonSolucion/pruebaJson/file2.json");

        Dictionary<string, string> prefijoNombre = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonTextPrefijoNombre);
        Dictionary<string, double> prefijoValor = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonTextPrefijoValor);

        // Combinar la información relevante en una nueva estructura
        string moneda = "EUR";
        double valor = 0;
        string nombre = "";

        Dictionary<string, string> todasLasMonedas = new Dictionary<string, string>();


        /*if (prefijoValor.ContainsKey(moneda) && prefijoNombre.ContainsKey(moneda))
        {
            valor = prefijoValor[moneda];
            nombre = prefijoNombre[moneda];
        }
        else
        {
            Console.WriteLine($"La moneda {moneda} no se encuentra en ambos archivos JSON.");
            return;
        }

        var resultado = new
        {
            Moneda = moneda,
            Valor = valor,
            Nombre = nombre
        };

        //Escribir la nueva estructura en un nuevo archivo JSON
        string jsonResultado = JsonConvert.SerializeObject(resultado, Formatting.Indented);
        // Colocar la nueva ubicacion del archivo creado de unir los dos archivos JSON
        File.WriteAllText("resultado.json", jsonResultado);

        //Console.WriteLine("Archivo resultado.json creado correctamente.");

        */
        foreach (var monedasResultado in prefijoValor)
        {
            if (prefijoNombre.ContainsKey(monedasResultado.Key))
            {
                todasLasMonedas[monedasResultado.Key] = $"{monedasResultado.Value} : {prefijoNombre[monedasResultado.Key]}";
            }
        }

        // Mostrar todas las monedas por consola
        foreach (var monedas in todasLasMonedas)
        {
            Console.WriteLine($"{monedas.Key}: {monedas.Value}");
        }

    }
}
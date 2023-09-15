namespace ApiJsonBiblioteca
{
    public class ApiMonedas
    {
        public List<MonedaJson> ObtenerMonedas()
        {
            return new List<MonedaJson>
            {
                new MonedaJson { CodigoMoneda  ="EUR",
                },
                new MonedaJson { CodigoMoneda = "USD"},
                new MonedaJson { CodigoMoneda = "GBP"}
            };
        }
    }
}
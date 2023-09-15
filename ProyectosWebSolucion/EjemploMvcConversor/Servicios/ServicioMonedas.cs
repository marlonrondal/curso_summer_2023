using EjemploMvcConversor.Models;

namespace EjemploMvcConversor.Servicios
{
    public class ServicioMonedas : IServicioMonedas
    {
        private readonly ILogger<ServicioMonedas> logger;

        public ServicioMonedas(ILogger<ServicioMonedas> logger)
        {
            this.logger = logger;
        }
        public List<Moneda> Monedas { get; set; }


        public List<Moneda> ObtenerMonedas()
        {
            return Monedas;
        }
    }
}

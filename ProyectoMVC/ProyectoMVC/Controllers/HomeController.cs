using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;
using ProyectoMVC.Servicios;
using System.Diagnostics;

namespace ProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioMonedas servicioMonedas;
        private readonly IMail mail;

        public HomeController(ILogger<HomeController> logger, IServicioMonedas servicioMonedas, IMail mail)
        {
            _logger = logger;
            this.servicioMonedas = servicioMonedas;
            this.mail = mail;
        }

        public IActionResult Index()
        {

            _logger.LogInformation("Estoy en el index");
            //var serviciomonedas = new ServicioMonedas();
            //var serviciomonedas = new ServicioCriptoMonedas();
            //IServicioMonedas serviciomonedas = new ServicioCriptoMonedas();
            var lista = this.servicioMonedas.ObtenerMonedas();

            return View();
        }

        public IActionResult Privacy()
        {

            //var serviciomonedas = new ServicioMonedas();
            //var serviciomonedas = new ServicioCriptoMonedas();
            //IServicioMonedas serviciomonedas = new ServicioCriptoMonedas();
            //var lista = this.servicioMonedas.ObtenerMonedas();
            var correo = this.mail.enviarEmail();
            _logger.LogInformation("Enviando correo " + correo);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
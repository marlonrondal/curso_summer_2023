using ProyectoMVC.Servicios;

namespace ProyectoMVC.Models
{
    public class MailProduccion: IMail

    {
        public string enviarEmail()
        {
            return "Producción";
        }



    }
}

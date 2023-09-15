using ProyectoMVC.Servicios;

namespace ProyectoMVC.Models
{
    public class MailDesarrollo : IMail
    {
        public string enviarEmail()
        {
            return "Desarrollo";
        }

    }
}

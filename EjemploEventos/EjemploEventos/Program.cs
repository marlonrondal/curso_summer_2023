namespace EjemploEventos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1-Crear instancia del reloj interno (Publicador)
            var reloj = new Reloj();

            // 2-Crear un reloj digital y nos suscribimos (Suscriptor)

            //var relojDigital = new RelojDigital();
            //relojDigital.Suscribir(reloj);
            //Crear un log o registro que guarde cada 10
            var log = new LogRegistro();
                log.Suscribir(reloj);
            //segundos la fecha y hora
            //
            // 3-Poner en marcha el reloj
            reloj.IniciaReloj();
        }
    }
}
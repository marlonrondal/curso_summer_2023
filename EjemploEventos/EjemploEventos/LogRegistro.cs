namespace EjemploEventos
{
    internal class LogRegistro
    {

        DateTime fecha1;
        DateTime fecha2;
        public LogRegistro()
        {
        }

        internal void Suscribir(Reloj reloj)
        {
            reloj.CambioSegundoEvento += Reloj_CambioSegundoEvento;
        }

        private void Reloj_CambioSegundoEvento(object reloj, InformacionTiempoEventArgs e)
        {
            fecha2 = DateTime.Now;
            TimeSpan interval = fecha2 - fecha1;
            var fecha = DateTime.Now.ToString("dd/MM/yyyy");

            if(interval.Seconds >=10)
            {
                Console.WriteLine($"Hora Actual: {e.Hora.ToString()} " +
                                              $"{e.Minuto.ToString()} " +
                                              $"{e.Segundo.ToString()} " +
                                              $"{fecha}");
                fecha1 = fecha2;
            }
            


        }
    }
}
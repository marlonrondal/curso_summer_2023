namespace EjemploMvcConversor.Models
{
    public class RepositorioMonedas : IRepositorioMonedas
    {

        private ContextoConversor _context;
        public RepositorioMonedas(ContextoConversor contexto)
        {
            _context = contexto;
        }

        public void AgregarMoneda(Moneda moneda)
        {
            _context.Monedas.Add(moneda);
            _context.SaveChanges();
        }

        public Moneda ObtenerMoneda(int id)
        {
            var moneda = _context.Monedas.FirstOrDefault(x => x.Id == id);
            return moneda;
        }

        public IEnumerable<Moneda> ObtenerMonedas()
        {
            return _context.Monedas;
        }
    }
}
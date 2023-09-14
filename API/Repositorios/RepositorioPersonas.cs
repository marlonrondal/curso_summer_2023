using Entidades;
using Context;
using Microsoft.EntityFrameworkCore;

namespace Repositorios
{
    public class RepositorioPersonas : IRepositorioPersonas
    {

        private readonly ContextPersonas _context;

        public RepositorioPersonas(ContextPersonas _context)
        {
            this._context = _context;
        }

        // Existe persona
        public bool exitePersona(Guid id)
        {
            Personas personas = _context.personas.FirstOrDefault(p => p.id == id);
            return personas != null ? true : false;
        }

        // Alta persona
        public async Task<Personas> altaPersona(Personas nuevaPersona)
        {
            if (exitePersona(nuevaPersona.id))
            {
                Personas existePersona = _context.personas.First(p => p.id == nuevaPersona.id);
                existePersona.nombre = nuevaPersona.nombre;
                existePersona.fechaNacimiento = nuevaPersona.fechaNacimiento;
                existePersona.telefono = nuevaPersona.telefono;
            }
            else
            {
                _context.personas.Add(nuevaPersona);
            }

            _context.SaveChanges();
            return nuevaPersona;
        }

        // Obtener Una Persona
        public async Task<Personas> obtenerPersona(Guid id)
        {

            return _context.personas.FirstOrDefault(p => p.id == id);
        }

        public async Task<IEnumerable<Personas>> obtenerTodasPersonas()
        {
            return await _context.personas.ToListAsync();
        }

        // Primeras 10 personas con más de 21 años ordenado por nombre
        public async Task<IEnumerable<Personas>> obtenerPrimeras10()
        {
            var personasMayoresDe21 = (await obtenerTodasPersonas()).ToList();

            var ultimosMayoresDe21 = personasMayoresDe21
                .Where(p => calcularEdad(p.fechaNacimiento) > 21)
                //.OrderBy(p => p.nombre)
                .ToList()  // Convertir a lista para usar TakeLast
                .TakeLast(10)
                .OrderBy(p=>p.nombre)
                .ToList();

            return ultimosMayoresDe21;
        }



        private int calcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;

            TimeSpan diferenciaFechas = fechaActual - fechaNacimiento;

            return diferenciaFechas.Days / 365;
        }

    }
}

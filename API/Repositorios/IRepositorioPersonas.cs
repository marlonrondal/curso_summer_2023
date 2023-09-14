using Entidades;

namespace Repositorios
{
    public interface IRepositorioPersonas
    {
        bool exitePersona(Guid id);
        Task<Personas> altaPersona(Personas nuevaPersona);
         Task<IEnumerable<Personas>> obtenerTodasPersonas();
        Task<Personas> obtenerPersona(Guid id);
        Task<IEnumerable<Personas>> obtenerPrimeras10();
    }
}
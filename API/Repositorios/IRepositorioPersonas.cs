using Entidades;

namespace Repositorios
{
    public interface IRepositorioPersonas
    {
        bool exitePersona(Guid id);
        Task<Personas> altaPersona(Personas nuevaPersona);
        Task<Personas> obtenerPersona(Guid id);
        Task<IEnumerable<Personas>> obtenerPrimeras10();
    }
}
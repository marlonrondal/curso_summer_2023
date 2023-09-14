using AutoMapper;
using Entidades;
using EntidadesDTO;
namespace API.Profiles
{
    public class PersonasProfile : Profile
    {
        public PersonasProfile()
        {
            CreateMap<Personas, PersonasVer>();
            CreateMap<CrearPersonas, Personas>();
        }
    }
}

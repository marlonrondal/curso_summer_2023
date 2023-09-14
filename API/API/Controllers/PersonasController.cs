using Microsoft.AspNetCore.Mvc;
using Context;
using Entidades;
using AutoMapper;
using EntidadesDTO;
using Repositorios;

namespace API.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ContextPersonas _context;
        private readonly IMapper _mapper;
        private readonly IRepositorioPersonas _repositorioPersonas;

        public PersonasController(ContextPersonas context, IMapper mapper, IRepositorioPersonas repositorioPersonas)
        {
            _context = context;
            _mapper = mapper;
            _repositorioPersonas = repositorioPersonas;
        }


        // GET: api/personas/{id}
        [HttpGet("{id}", Name = "GetPersonas")]
        public async Task<ActionResult<PersonasVer>> getUnaPersona([FromRoute] string id)
        {
            if (!Guid.TryParse(id, out Guid idGuid))
            {
                return BadRequest("El valor proporcionado no es un Guid válido");
            }

            var persona = await _repositorioPersonas.obtenerPersona(idGuid);

            if (persona == null)
            {
                return Ok("No existe ningún usuario con ese id");
            }

            var personaDto = _mapper.Map<PersonasVer>(persona);
            return Ok(personaDto);
        }

        // GET: api/personas/ultimos10
        [HttpGet("ultimos10")]
        public async Task<ActionResult<IEnumerable<PersonasVer>>> getPrimeras10()
        {
            var ultimosMayoresDe21 = await _repositorioPersonas.obtenerPrimeras10();

            var ultimosMayoresDe21Dto = _mapper.Map<List<PersonasVer>>(ultimosMayoresDe21);
            return Ok(ultimosMayoresDe21Dto);
        }

        // POST: api/personas
        [HttpPost]
        public async Task<ActionResult<PersonasVer>> postAltaPErsona([FromBody] CrearPersonas personaDto)
        {
            if (personaDto == null) return NotFound("Los datos de la persona son nulos.");

            var nuevaPersona = _mapper.Map<Personas>(personaDto);
            var result = await _repositorioPersonas.altaPersona(nuevaPersona);
            var resultDto = _mapper.Map<PersonasVer>(result);

            return Ok(personaDto);
        }
    }
}

using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers;

[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly ICourseLibraryRepository _courseLibraryRepository;
    private readonly IMapper _mapper;

    public AuthorsController(
        ICourseLibraryRepository courseLibraryRepository,
        IMapper mapper)
    {
        _courseLibraryRepository = courseLibraryRepository ??
            throw new ArgumentNullException(nameof(courseLibraryRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("api/author")]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        // get authors from repo
        var authorsFromRepo = await _courseLibraryRepository
            .GetAuthorsAsync();

        // return them
        return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
    }
    //route("api/author")
    //              [FromRoute]
    //api/autohrs/{authorId}
    [HttpGet("{authorId}", Name = "GetAuthor")]
    public async Task<ActionResult<AuthorDto>> GetAuthor([FromRoute] Guid authorId)
    {
        // get author from repo
        var authorFromRepo = await _courseLibraryRepository.GetAuthorAsync(authorId);

        if (authorFromRepo == null)
        {
            //!Status = 404
            return NotFound();
        }
        // return author
        //!Status = 200
        
        return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
    }
    //Route("api/authors")
    
    //api/authors
    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] AuthorDto author) //DTO
    {
        var authorEntity = _mapper.Map<Entities.Author>(author); //convertir DTO -> Entidad

        _courseLibraryRepository.AddAuthor(authorEntity);//Entidad
        await _courseLibraryRepository.SaveAsync();

        var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);//Entidad -> DTO


        //!Status = 201
        //    nombre de la ruta
        return CreatedAtRoute("GetAuthor",
            //  parametros de la ruta (Tipo anonimo)
            new { authorId = authorToReturn.Id },

            //Registro creado en DTO
            authorToReturn);                          // DTO
    }
}

using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers;

[ApiController] 
[Route("api/authors")]
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

    [HttpGet] 
    [HttpHead]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        // throw new Exception("Test exception");

        // get authors from repo
        var authorsFromRepo = await _courseLibraryRepository
            .GetAuthorsAsync(); 

        // return them
        //! STATUS = 200
        return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
    }

    //  Route("api/authors")
    //                  [FromRoute] 
    //+ api/authors/{authorid}
    [HttpGet("{authorId}", Name = "GetAuthor")]
    public async Task<ActionResult<AuthorDto>> GetAuthor([FromRoute]    Guid authorId)
    {
        // get author from repo
        var authorFromRepo = await _courseLibraryRepository
            .GetAuthorAsync(authorId);

        if (authorFromRepo == null)
        {
            //! STATUS = 404
            return NotFound();
        }

        // return author
        //! STATUS = 200
        return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
    }



    //  Route("api/authors")
    //                   
    //+ api/authors/
    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody]  AuthorForCreationDto author) //+ DTO
    {
        var authorEntity = _mapper.Map<Entities.Author>(author); //+ DTO -> ENTIDAD

        _courseLibraryRepository.AddAuthor(authorEntity); //+ ENTIDAD
        await _courseLibraryRepository.SaveAsync();

        var authorToReturn = _mapper.Map<AuthorDto>(authorEntity); //+ ENTIDAD -> DTO

        //! STATUS = 201
        //                    Nombre de la ruta   
        return CreatedAtRoute("GetAuthor", 
        //                    Parámetros de la ruta (Tipo anómimo
                              new { authorId = authorToReturn.Id },
        //                    Registro creado en DTO
                              authorToReturn);                           //+ DTO 
    }
}

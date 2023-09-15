using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers;

[ApiController]
[Route("api/authors/{authorId}/courses")]
public class CoursesController : ControllerBase
{
    private readonly ICourseLibraryRepository _courseLibraryRepository;
    private readonly IMapper _mapper;

    public CoursesController(ICourseLibraryRepository courseLibraryRepository,
        IMapper mapper)
    {
        _courseLibraryRepository = courseLibraryRepository ??
            throw new ArgumentNullException(nameof(courseLibraryRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetCoursesForAuthor(
        Guid authorId)
    {
        if (!await _courseLibraryRepository.AuthorExistsAsync(authorId))
        {
            return NotFound();
        }

        var coursesForAuthorFromRepo = await _courseLibraryRepository
            .GetCoursesAsync(authorId);
        return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesForAuthorFromRepo));
    }

    [HttpGet("{courseId}", Name = "GetCourseForAuthor")]
    public async Task<ActionResult<CourseDto>> GetCourseForAuthor(
        Guid authorId, Guid courseId)
    {
        if (!await _courseLibraryRepository.AuthorExistsAsync(authorId))
        {
            return NotFound();
        }

        var courseForAuthorFromRepo = await _courseLibraryRepository
            .GetCourseAsync(authorId, courseId);

        if (courseForAuthorFromRepo == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<CourseDto>(courseForAuthorFromRepo));
    }


    [HttpPost]
    public async Task<ActionResult<CourseDto>> CreateCourseForAuthor(
            Guid authorId, CourseForCreationDto course)
    {
        if (!await _courseLibraryRepository.AuthorExistsAsync(authorId))
        {
            return NotFound();
        }

        var courseEntity = _mapper.Map<Entities.Course>(course);
        _courseLibraryRepository.AddCourse(authorId, courseEntity);
        await _courseLibraryRepository.SaveAsync();

        var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

        return CreatedAtRoute("GetCourseForAuthor",
            new { authorId, courseId = courseToReturn.Id },
            courseToReturn);
        }


    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateCourseForAuthor(Guid authorId,
      Guid courseId,
      CourseForUpdateDto course)
        //+1 Comprobar si existe el registro
    {
        if (!await _courseLibraryRepository.AuthorExistsAsync(authorId))
        {
            return NotFound();
        }

        //+2 Obtener registro

        var courseForAuthorFromRepo = await _courseLibraryRepository
            .GetCourseAsync(authorId, courseId);
        

        //if (courseForAuthorFromRepo == null)
        //{
        //    var courseToAdd = _mapper.Map<Entities.Course>(course);
        //    courseToAdd.Id = courseId;
        //    _courseLibraryRepository.AddCourse(authorId, courseToAdd);
        //    await _courseLibraryRepository.SaveAsync();

        //    var courseToReturn = _mapper.Map<CourseDto>(courseToAdd);
        //    return CreatedAtRoute("GetCourseForAuthor",
        //        new { authorId, courseId = courseToReturn.Id }, 
        //        courseToReturn);
        //}
        //+ 3 Mapear de DTO que entra a entidad
        _mapper.Map(course, courseForAuthorFromRepo);
        //+ 4Actualizar mediante repo
        _courseLibraryRepository.UpdateCourse(courseForAuthorFromRepo);
        //+ 5 Guardar cambios
        await _courseLibraryRepository.SaveAsync();
        //+ Devolver NoContent 
        return NoContent();
    }

    [HttpPatch("{courseId}")]
    public async Task<IActionResult> PartiallyUpdateCourseForAuthor(
        Guid authorId,
        Guid courseId,
        JsonPatchDocument<CourseForUpdateDto> patchDocument)
        //+1 Comprobar si el registro exite
    {
        if (!await _courseLibraryRepository.AuthorExistsAsync(authorId))
        {
            return NotFound();
        }
        //+2 Obtener el registro entidad
        var courseForAuthorFromRepo = await _courseLibraryRepository
            .GetCourseAsync(authorId, courseId);

        //if (courseForAuthorFromRepo == null)
        //{
        //    var courseDto = new CourseForUpdateDto();
        //    patchDocument.ApplyTo(courseDto);
        //    var courseToAdd = _mapper.Map<Entities.Course>(courseDto);
        //    courseToAdd.Id = courseId;

        //    _courseLibraryRepository.AddCourse(authorId, courseToAdd);
        //    await _courseLibraryRepository.SaveAsync();

        //    var courseToReturn = _mapper.Map<CourseDto>(courseToAdd);
        //    return CreatedAtRoute("GetCourseForAuthor",
        //        new { authorId, courseId = courseToReturn.Id }, 
        //        courseToReturn);
        //}

        //+3 Crear una copia del registro
        //+para aplicar los cambios entidad a dto
        var courseToPatch = _mapper.Map<CourseForUpdateDto>(
            courseForAuthorFromRepo);
        //+4 Aplicamos los cambios
        //+(n cambios descritos en el JsonPatch Document)
        //+DTO para actualizar 
        patchDocument.ApplyTo(courseToPatch);

        //+5 Convertimos a ENT
        //+dto para actualizar a ent

        _mapper.Map(courseToPatch, courseForAuthorFromRepo);
        //+6 actualizar mendiante repo

        _courseLibraryRepository.UpdateCourse(courseForAuthorFromRepo);
        //+7 actualizar a BBDD

        await _courseLibraryRepository.SaveAsync();

        return NoContent();
    }


    [HttpDelete("{courseId}")]
    public async Task<ActionResult> DeleteCourseForAuthor(
        Guid authorId, Guid courseId)
    {
        if (!await _courseLibraryRepository.AuthorExistsAsync(authorId))
        {
            return NotFound();
        }

        var courseForAuthorFromRepo = await _courseLibraryRepository
            .GetCourseAsync(authorId, courseId);

        if (courseForAuthorFromRepo == null)
        {
            return NotFound();
        }

        _courseLibraryRepository.DeleteCourse(courseForAuthorFromRepo);
        await _courseLibraryRepository.SaveAsync();

        return NoContent();
    }

}
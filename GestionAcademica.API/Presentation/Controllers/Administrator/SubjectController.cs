using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Administrator;

[ApiController]
[Route("api/administrator/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly IDetailSubjectUseCase _detailSubjectUseCase;

    public SubjectController(IDetailSubjectUseCase detailSubjectUseCase)
    {
        _detailSubjectUseCase = detailSubjectUseCase;
    }
    
    [HttpGet]
    public IActionResult SubjectListSimple()
    {
        try
        {
            return Ok(_detailSubjectUseCase.ObtainAllSubjects());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult UpdateSubject(SubjectDTO subject)
    {
        try
        {
            _detailSubjectUseCase.UpdateSubject(subject);
            return Ok(new { message = "Asignatura actualizada correctamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult SubjectById(int id)
    {
        try
        {

            return Ok(_detailSubjectUseCase.ObtainSubjectById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
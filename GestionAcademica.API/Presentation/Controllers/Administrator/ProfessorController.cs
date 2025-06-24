using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Administrator;


[ApiController]
[Route("api/administrator/[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorManagementUseCase _professorManagementUseCase;

    public ProfessorController(IProfessorManagementUseCase professorManagementUseCase)
    {
        _professorManagementUseCase = professorManagementUseCase;
    }
    
    [HttpPost]
    public IActionResult CreateProfessor([FromBody] CreateProfessorDTO createProfessorDto)
    {
        try
        {
            ResponseProfessorDTO professor = _professorManagementUseCase.RegisterProfessor(createProfessorDto);
            return Ok(professor);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult UpdateProfessor(UpdateProfessorDTO updateProfessorDto)
    {
        try
        {
            _professorManagementUseCase.UpdateProfessor(updateProfessorDto);
            return Ok(new { message = "Docente actualizado correctamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
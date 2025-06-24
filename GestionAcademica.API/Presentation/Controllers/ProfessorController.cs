using GestionAcademica.API.Application.DTOs.Professor;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Administrator;

[ApiController]
[Route("api/[controller]")]
public class PublicProfessorController : ControllerBase
{
    private readonly IDetailProfessorUseCase _detailProfessorUseCase;

    public PublicProfessorController(IDetailProfessorUseCase detailProfessorUseCase)
    {
        _detailProfessorUseCase = detailProfessorUseCase;
    }

    [HttpGet]
    public IActionResult ProfessorListSimple()
    {
        try
        {
            var result = _detailProfessorUseCase.ObtainAllProfessors();
            if (result == null || result.Count == 0)
            {
                return NotFound("No se encontraron profesores");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetProfessorInformation(int id)
    {
        try
        {
            return Ok(_detailProfessorUseCase.GetProfessorInformation(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
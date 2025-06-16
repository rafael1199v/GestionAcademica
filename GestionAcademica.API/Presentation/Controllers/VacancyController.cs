using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VacancyController : ControllerBase
{
    private readonly ICreateVacancyUseCase _createVacancyUseCase;

    public VacancyController(ICreateVacancyUseCase createVacancyUseCase)
    {
        _createVacancyUseCase = createVacancyUseCase;
    }



    [HttpPost]
    public IActionResult CreateVacancy([FromBody] CreateVacancyDTO createVacancyDto)
    {
        try
        {
            _createVacancyUseCase.CreateVacancy(createVacancyDto);
            return Ok("Vacante creada correctamente");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("subjects-with-careers")]
    public IActionResult GetSubjectWithVacancies()
    {
        try
        {
            return Ok(_createVacancyUseCase.GetSubjectsWithCareers());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
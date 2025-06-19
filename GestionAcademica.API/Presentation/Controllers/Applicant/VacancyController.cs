using GestionAcademica.API.Application.DTOs.Application;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Applicant;


[ApiController]
[Route("api/applicant/[controller]")]
public class VacancyController : ControllerBase
{
    
    private readonly IApplyForVacancy _applyForVacancy;

    public VacancyController(IApplyForVacancy applyForVacancy)
    {
        _applyForVacancy = applyForVacancy;
    }
    
    [HttpPost]
    [Route("apply")]
    public IActionResult ApplyToVacancy([FromForm] CreateApplicationDTO createApplicationDto)
    {
        try
        {
            _applyForVacancy.Apply(createApplicationDto);
            return Ok("Postulacion creada correctamente");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet]
    public IActionResult GetAvailableVacancies()
    {
        try
        {
            return Ok(_applyForVacancy.GetAvailableVacancies());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
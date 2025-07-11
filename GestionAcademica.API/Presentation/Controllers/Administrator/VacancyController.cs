using GestionAcademica.API.Application.DTOs.Vacancy;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Administrator;


[ApiController]
[Route("api/administrator/[controller]")]
public class VacancyController : ControllerBase
{
    private readonly ICreateVacancyUseCase _createVacancyUseCase;
    private readonly IManageVacancies _manageVacancies;


    public VacancyController(ICreateVacancyUseCase createVacancyUseCase, IManageVacancies manageVacancies)
    {
        _createVacancyUseCase = createVacancyUseCase;
        _manageVacancies = manageVacancies;
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
    [Route("{userId}")]
    public IActionResult GetVacancies(int userId)
    {
        try
        {
            return Ok(_manageVacancies.GetVacancies(userId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult UpdateVacancy([FromBody] UpdateVacancyDTO updateVacancyDto)
    {
        try
        {
            _manageVacancies.UpdateVacancy(updateVacancyDto);
            return Ok("Vacante actualizada correctamente");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("update/{vacancyId}")]
    public IActionResult GetVacancyToUpdate(int vacancyId)
    {
        try
        {
            return Ok(_manageVacancies.GetVacancyToUpdate(vacancyId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete]
    [Route("{vacancyId}")]
    public IActionResult DeleteVacancy(int vacancyId)
    {
        try
        {
            _manageVacancies.DeleteVacancy(vacancyId);
            return Ok("Vacante eliminada correctamente");
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
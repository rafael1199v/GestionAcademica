using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Administrator;



[ApiController]
[Route("api/administrator/[controller]")]
public class ApplicationController : ControllerBase
{
    
    private readonly IReviewSubmittedApplicationsUseCase _reviewSubmittedApplicationsUseCase;
    private readonly IHireApplicantUseCase _hireApplicantUseCase;

    public ApplicationController(IReviewSubmittedApplicationsUseCase reviewSubmittedApplicationsUseCase, IHireApplicantUseCase hireApplicantUseCase)
    {
        _reviewSubmittedApplicationsUseCase = reviewSubmittedApplicationsUseCase;
        _hireApplicantUseCase = hireApplicantUseCase;
    }
    
    [HttpGet]
    [Route("vacancy/{vacancyId}")]
    public IActionResult GetApplicationsByVacancy(int vacancyId)
    {
        try
        {
            return Ok(_reviewSubmittedApplicationsUseCase.GetInterviewApplications(vacancyId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [Route("reject/{applicationId}")]
    public IActionResult RejectApplication(int applicationId)
    {
        try
        {
            _reviewSubmittedApplicationsUseCase.RejectInterviewApplicaiton(applicationId);
            return Ok("Postulacion rechazada correctamente");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [Route("hire/{applicationId}")]
    public IActionResult HireApplicant(int applicationId)
    {
        try
        {
            return Ok(_hireApplicantUseCase.HireApplicantByApplication(applicationId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("{applicationId}")]
    public IActionResult GetDetailInterviewApplication(int applicationId)
    {
        try
        {
            return Ok(_reviewSubmittedApplicationsUseCase.GetDetailInterviewApplication(applicationId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
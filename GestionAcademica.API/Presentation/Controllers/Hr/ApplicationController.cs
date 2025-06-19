using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Hr;

[ApiController]
[Route("api/hr/[controller]")]
public class ApplicationController : ControllerBase
{
    
    
    private readonly IReviewNewApplicationsUseCase _reviewNewApplicationsUseCase;

    public ApplicationController(IReviewNewApplicationsUseCase reviewNewApplicationsUseCase)
    {
        _reviewNewApplicationsUseCase = reviewNewApplicationsUseCase;
    }
    
    
    [HttpGet]
    public IActionResult GetNewApplications()
    {
        try
        {
            return Ok(_reviewNewApplicationsUseCase.GetNewApplications());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet]
    [Route("{applicationId}")]
    public IActionResult GetApplicationDetail(int applicationId)
    {
        try
        {
            return Ok(_reviewNewApplicationsUseCase.GetDetailNewApplication(applicationId));
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
            _reviewNewApplicationsUseCase.RejectApplication(applicationId);
            return Ok("Postulacion rechazada correctamente");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [Route("approve/{applicationId}")]
    public IActionResult ApproveApplication(int applicationId)
    {
        try
        {
            _reviewNewApplicationsUseCase.AdvanceApplicationToInterview(applicationId);
            return Ok("Postulacion actualizada correctamente. Ahora se encuentra en la fase de entrevista");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
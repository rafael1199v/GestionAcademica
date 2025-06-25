using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Applicant;

[ApiController]
[Route("api/applicant/[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly IViewOwnApplications _viewOwnApplications;
    public ApplicationController(IViewOwnApplications viewOwnApplications)
    {
        _viewOwnApplications = viewOwnApplications;
    }
    
    [HttpGet]
    [Route("{applicantId}")]
    public IActionResult GetOwnApplications(int applicantId)
    {
        try
        {
            return Ok(_viewOwnApplications.GetOwnApplications(applicantId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpGet]
    [Route("detail/{applicationId}")]
    public IActionResult GetDetailApplication(int applicationId)
    {
        try
        {
            return Ok(_viewOwnApplications.GetApplicationDetail(applicationId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    

}
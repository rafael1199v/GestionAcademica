using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Applicant;

[ApiController]
[Route("api/applicant/[controller]")]
public class ApplicationController : ControllerBase
{
    [HttpGet]
    [Route("{applicantId}")]
    public IActionResult GetApplicationsByApplicantId(int applicantId)
    {
        return Ok();
    }

    

}
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Administrator;



[ApiController]
[Route("api/administrator/[controller]")]
public class ApplicationController : ControllerBase
{
    [HttpGet]
    [Route("vacancy/{vacancyId}")]
    public IActionResult GetApplicationsByVacancy(int vacancyId)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("reject/{applicationId}")]
    public IActionResult RejectApplication(int applicationId)
    {
        return Ok();
    }

    [HttpPatch]
    [Route("hire/{applicationId}")]
    public IActionResult HireApplicant(int applicationId)
    {
        return Ok();
    }
}
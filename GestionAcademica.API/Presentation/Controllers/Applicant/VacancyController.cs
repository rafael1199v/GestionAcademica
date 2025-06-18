using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Applicant;


[ApiController]
[Route("api/applicant/[controller]")]
public class VacancyController : ControllerBase
{
    [HttpPost]
    [Route("apply")]
    public IActionResult ApplyToVacancy()
    {
        return Ok();
    }

}
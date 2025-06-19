using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers.Hr;

[ApiController]
[Route("api/hr/[controller]")]
public class ApplicationController : ControllerBase
{
    [HttpGet]
    public IActionResult GetApplications()
    {
        try
        {
            return Ok();
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
            return Ok();
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
            return Ok();
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
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
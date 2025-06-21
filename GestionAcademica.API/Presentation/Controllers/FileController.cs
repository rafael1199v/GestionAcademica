using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IManageFileUseCase _manageFileUseCase;

    public FileController(IManageFileUseCase manageFileUseCase)
    {
        _manageFileUseCase = manageFileUseCase;
    }


    [HttpGet]
    [Route("{fileId}")]
    public IActionResult DownloadFileById(int fileId)
    {
        try
        {
            var file = _manageFileUseCase.DownloadFile(fileId);
            
            return File(file.Bytes, file.ContentType, $"{file.FileName}{file.FileExtension}");
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}
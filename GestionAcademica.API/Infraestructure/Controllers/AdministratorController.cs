using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Administrator.Infraestructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IRegisterProfessorUseCase _registerProfessorUseCase;

        public AdministratorController(IRegisterProfessorUseCase registerProfessorUseCase)
        {
            _registerProfessorUseCase = registerProfessorUseCase;
        }
        
        [HttpPost]
        [Route("professor")]
        public  IActionResult CreateProfessor([FromBody] CreateProfessorDTO createProfessorDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                ResponseProfessorDTO professor = _registerProfessorUseCase.CreateProffesor(createProfessorDto);
                return Ok(professor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

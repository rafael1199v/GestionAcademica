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
        private readonly IRegisterStudentUseCase _registerStudentUseCase;

        public AdministratorController(IRegisterProfessorUseCase registerProfessorUseCase, IRegisterStudentUseCase registerStudentUseCase)
        {
            _registerProfessorUseCase = registerProfessorUseCase;
            _registerStudentUseCase = registerStudentUseCase;
        }

        [HttpPost]
        [Route("student")]
        public IActionResult CreateStudent([FromBody] StudentDTO studentDTO)
        {
            try
            {
                _registerStudentUseCase.CreateStudent(studentDTO);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("professor")]
        public  IActionResult CreateProfessor([FromBody] ProfessorDTO professorDTO)
        {
            try
            {
                _registerProfessorUseCase.CreateProffesor(professorDTO);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

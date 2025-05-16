using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using GestionAcademica.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Administrator.Infraestructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IRegisterProfessorUseCase _registerProfessorUseCase;
        private readonly IDetailProfessorUseCase _detailProfessorUseCase;

        public AdministratorController(IRegisterProfessorUseCase registerProfessorUseCase, IDetailProfessorUseCase detailProfessorUseCase)
        {
            _registerProfessorUseCase = registerProfessorUseCase;
            _detailProfessorUseCase = detailProfessorUseCase;
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

        [HttpGet]
        [Route("professor")]
        public IActionResult ProfessorListSimple()
        {
            try
            {
                return Ok(_detailProfessorUseCase.ObtainAllProfessors());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

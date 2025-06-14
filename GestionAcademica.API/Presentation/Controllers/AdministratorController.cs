using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IDetailSubjectUseCase _detailSubjectUseCase;
        private readonly IProfessorManagementUseCase _professorManagementUseCase;

        public AdministratorController(IDetailSubjectUseCase detailSubjectUseCase,
            IProfessorManagementUseCase professorManagementUseCase)
        {
            _detailSubjectUseCase = detailSubjectUseCase;
            _professorManagementUseCase = professorManagementUseCase;
        }

        [HttpPost]
        [Route("professor")]
        public IActionResult CreateProfessor([FromBody] CreateProfessorDTO createProfessorDto)
        {
            try
            {
                ResponseProfessorDTO professor = _professorManagementUseCase.RegisterProfessor(createProfessorDto);
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
                var result = _professorManagementUseCase.ObtainAllProfessors();
                if (result == null || result.Count == 0)
                {
                    return NotFound("No se encontraron profesores");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("professor")]
        public IActionResult UpdateProfessor(UpdateProfessorDTO updateProfessorDto)
        {
            try
            {
                _professorManagementUseCase.UpdateProfessor(updateProfessorDto);
                return Ok(new { message = "Docente actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("professor/{id}")]
        public IActionResult GetProfessorInformation(int id)
        {
            try
            {
                return Ok(_professorManagementUseCase.GetProfessorInformation(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("subject")]
        public IActionResult SubjectListSimple()
        {
            try
            {
                return Ok(_detailSubjectUseCase.ObtainAllSubjects());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("subject")]
        public IActionResult UpdateSubject(SubjectDTO subject)
        {
            try
            {
                _detailSubjectUseCase.UpdateSubject(subject);
                return Ok(new { message = "Asignatura actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("subject/{id}")]
        public IActionResult SubjectById(int id)
        {
            try
            {

                return Ok(_detailSubjectUseCase.ObtainSubjectById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

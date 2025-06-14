using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IRegisterProfessorUseCase _registerProfessorUseCase;
        private readonly IDetailProfessorUseCase _detailProfessorUseCase;
        private readonly IGetProfessorInformationUseCase _getProfessorInformationUseCase;
        private readonly IDetailSubjectUseCase _detailSubjectUseCase;
        private readonly IUpdateProfessorUseCase _updateProfessorUseCase;

        public AdministratorController(IRegisterProfessorUseCase registerProfessorUseCase,
            IDetailProfessorUseCase detailProfessorUseCase, IGetProfessorInformationUseCase getProfessorInformationUseCase,
            IUpdateProfessorUseCase updateProfessorUseCase, IDetailSubjectUseCase detailSubjectUseCase)
        {
            _registerProfessorUseCase = registerProfessorUseCase;
            _detailProfessorUseCase = detailProfessorUseCase;
            _getProfessorInformationUseCase = getProfessorInformationUseCase;
            _updateProfessorUseCase = updateProfessorUseCase;
            _detailSubjectUseCase = detailSubjectUseCase;
        }

        [HttpPost]
        [Route("professor")]
        public IActionResult CreateProfessor([FromBody] CreateProfessorDTO createProfessorDto)
        {
            try
            {
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
                var result = _detailProfessorUseCase.ObtainAllProfessors();
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
                _updateProfessorUseCase.UpdateProfessorRun(updateProfessorDto);
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
                return Ok(_getProfessorInformationUseCase.GetProfessorInformationRun(id));
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

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
        private readonly IGetProfessorInformation _getProfessorInformation;
        private readonly IDetailSubjectUseCase _detailSubjectUseCase;

        public AdministratorController(IRegisterProfessorUseCase registerProfessorUseCase,
            IDetailProfessorUseCase detailProfessorUseCase, IGetProfessorInformation getProfessorInformation, IDetailSubjectUseCase detailSubjectUseCase)
        {
            _registerProfessorUseCase = registerProfessorUseCase;
            _detailProfessorUseCase = detailProfessorUseCase;
            _getProfessorInformation = getProfessorInformation;
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
                return Ok(_detailProfessorUseCase.ObtainAllProfessors());
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
                return Ok(_getProfessorInformation.GetProfessorInformationRun(id));
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
                // _detailSubjectUseCase.UpdateSubject(subject);
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

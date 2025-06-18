// using GestionAcademica.API.Application.DTOs;
// using GestionAcademica.API.Application.DTOs.Application;
// using GestionAcademica.API.Application.Interfaces.UseCases;
// using Microsoft.AspNetCore.Mvc;
// namespace GestionAcademica.API.Presentation.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ApplicationController : ControllerBase
//     {
//         private readonly IApplicationManagementUseCase _applicationManagementUseCase;
//         public ApplicationController(IApplicationManagementUseCase applicationManagementUseCase)
//         {
//             _applicationManagementUseCase = applicationManagementUseCase;
//         }
//         [HttpPost]
//         [Route("application")]
//         public IActionResult CreateApplication([FromBody] ApplicationDTO application)
//         {
//             try
//             {
//                 _applicationManagementUseCase.CreateApplication(application);
//                 return Ok("Postulación creada correctamente");
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//         [HttpPut]
//         [Route("application")]
//         public IActionResult UpdateApplication([FromBody] ApplicationDTO application)
//         {
//             try
//             {
//                 _applicationManagementUseCase.UpdateApplication(application);
//                 return Ok("Postulación actualizada correctamente");
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//         [HttpGet]
//         [Route("application/{id}")]
//         public IActionResult GetApplicationById(int id)
//         {
//             try
//             {
//                 var application = _applicationManagementUseCase.GetApplicationById(id);
//                 return application == null ? NotFound("No se encontraron postulaciones para esta vacante") : Ok(application);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//         
//         [HttpGet]
//         [Route("application/vacancy/{vacancyId}")]
//         public IActionResult GetApplicationsByVacancyId(int vacancyId)
//         {
//             try
//             {
//                 var applications = _applicationManagementUseCase.GetApplicationsByVacancyId(vacancyId);
//                 if (applications == null || applications.Count == 0)
//                 {
//                     return NotFound("No se encontraron postulaciones para esta vacante");
//                 }
//                 return Ok(applications);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//         [HttpGet]
//         [Route("application/applicant/{applicantId}")]
//         public IActionResult GetApplicationsByApplicantId(int applicantId)
//         {
//             try
//             {
//                 var applications = _applicationManagementUseCase.GetApplicationsByApplicantId(applicantId);
//                 if (applications == null || applications.Count == 0)
//                 {
//                     return NotFound("No se encontraron postulaciones para este postulante");
//                 }
//                 return Ok(applications);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//         [HttpGet]
//         [Route("application/status/{statusId}")]
//         public IActionResult GetApplicationsByStatusId(int statusId)
//         {
//             try
//             {
//                 var applications = _applicationManagementUseCase.GetApplicationsByStatusId(statusId);
//                 if (applications == null || applications.Count == 0)
//                 {
//                     return NotFound("No se encontraron postulaciones con este estado");
//                 }
//                 return Ok(applications);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//         [HttpGet]
//         [Route("application/owner/{adminId}")]
//         public IActionResult GetApplicationsByOwnerId(int adminId)
//         {
//             try
//             {
//                 var applications = _applicationManagementUseCase.GetApplicationsByOwnerId(adminId);
//                 if (applications == null || applications.Count == 0)
//                 {
//                     return NotFound("No se encontraron postulaciones para este administrador");
//                 }
//                 return Ok(applications);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//     }
// }
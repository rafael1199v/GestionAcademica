using GestionAcademica.API.Application.DTOs;
using GestionAcademica.API.Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;

        public AuthController(ILoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthDTO request)
        {
            try
            {
                var userCred = _loginUseCase.Login(request.Email, request.Password);
                return Ok(new { userId = userCred.Item1, roleId = userCred.Item2, userRoleId = userCred.Item3 });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserDTO userDto)
        {
            try
            {
                _loginUseCase.SignUp(userDto);
                return Ok("Usuario registrado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
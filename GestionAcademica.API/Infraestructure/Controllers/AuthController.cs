using GestionAcademica.API.Application.Abstractions;
using GestionAcademica.API.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Infraestructure.Controllers
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
                return Ok(new { userId = userCred.Item1, roleId = userCred.Item2 });
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
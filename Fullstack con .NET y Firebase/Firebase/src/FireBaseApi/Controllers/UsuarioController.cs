using FireBaseApi.Dtos.Login;
using FireBaseApi.Dtos.UsuarioRegister;
using FireBaseApi.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FireBaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;


        public UsuarioController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioRegisterRequestDto request)
        {

            var uid = await _authenticationService.RegisterAsync(request);

            return Ok(new
            {
                Uid = uid,
                Message = "Usuario registrado correctamente"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {

            var uid = await _authenticationService.LoginAsync(request);

            return Ok(new
            {
                Uid = uid,
                Message = "Usuario ingresado correctamente"
            });
        }
    }
}

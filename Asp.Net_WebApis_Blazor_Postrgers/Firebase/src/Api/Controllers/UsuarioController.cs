using Api.Dtos.Login;
using Api.Dtos.UsuarioRegister;
using Api.Models.Domain;
using Api.Pagination;
using Api.Services.Authentication;
using Firebase.Api.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public UsuarioController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] UsuarioRegisterRequestDto request)
        {
            return await authenticationService.RegisterAsync(request);
                
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequestDto request)
        {
            return await authenticationService.LoginAsync(request);
        }

        [AllowAnonymous]
        [HttpGet("paginationv1")]
        public async Task<ActionResult<PagedResults<Usuario>>> GetPaginationV1(
            [FromQuery] PaginationParams paginationQuery
        )
        {
            var resultados = await authenticationService.GetPaginationVersion1(paginationQuery);
            return Ok(resultados);
        }

        [AllowAnonymous]
        [HttpGet("paginationv2")]
        public async Task<ActionResult<PagedResults<Usuario>>> GetPaginationV2(
            [FromQuery] PaginationParams paginationQuery
        )
        {
            var resultados = await authenticationService.GetPaginationVersion2(paginationQuery);
            return Ok(resultados);
        }
    }
}
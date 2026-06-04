using Api.Dtos.Login;
using Api.Dtos.UsuarioRegister;

namespace Api.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(UsuarioRegisterRequestDto request);
        Task<string> LoginAsync(LoginRequestDto request);
    }
}
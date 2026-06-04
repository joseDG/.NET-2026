using FireBaseApi.Dtos.Login;
using FireBaseApi.Dtos.UsuarioRegister;

namespace FireBaseApi.Services.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(UsuarioRegisterRequestDto request);
    Task<string> LoginAsync(LoginRequestDto request);
}
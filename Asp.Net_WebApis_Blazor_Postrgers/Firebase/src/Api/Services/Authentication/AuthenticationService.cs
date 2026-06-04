using Api.Dtos.Login;
using Api.Dtos.UsuarioRegister;
using Api.Models;
using FirebaseAdmin.Auth;

namespace Api.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

    private readonly HttpClient httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
            this.httpClient = httpClient;
    }

    public async Task<string> LoginAsync(LoginRequestDto request)
    {
        var credentials = new
        {
            request.Email,
            request.Password,
            returnSecureToken = true
        };

        var response = await httpClient.PostAsJsonAsync("", credentials);

        var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();

        return authFirebaseObject!.IdToken!;
    }

    public async Task<string> RegisterAsync(UsuarioRegisterRequestDto request)
        {
            var userArgs = new UserRecordArgs()
            {
                Email = request.Email,
                Password = request.Password
            };

            var usuario = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

            return usuario.Uid;
        }
    }
}
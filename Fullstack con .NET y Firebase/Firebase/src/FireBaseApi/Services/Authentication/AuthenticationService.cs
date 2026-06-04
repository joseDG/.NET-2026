using FirebaseAdmin.Auth;
using FireBaseApi.Dtos.Login;
using FireBaseApi.Dtos.UsuarioRegister;
using FireBaseApi.Models;

namespace FireBaseApi.Services.Authentication
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

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Credenciales erroneas");
            }

            var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();

            return authFirebaseObject!.IdToken!;
        }


        public async Task<string> RegisterAsync(UsuarioRegisterRequestDto request)
        {
            var userArgs = new UserRecordArgs
            {
                DisplayName = request.FullNombre,
                Email = request.Email,
                Password = request.Password
            };

            var usuario = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

            return usuario.Uid;
        }

        
    }
}

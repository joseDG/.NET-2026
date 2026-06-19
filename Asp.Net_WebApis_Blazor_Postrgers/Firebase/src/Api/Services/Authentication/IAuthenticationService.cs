using Api.Dtos.Login;
using Api.Dtos.UsuarioRegister;
using Api.Models.Domain;
using Api.Pagination;
using Api.Vms;
using Firebase.Api.Pagination;

namespace Api.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(UsuarioRegisterRequestDto request);
        Task<string> LoginAsync(LoginRequestDto request);
        Task<Usuario?> GetUserByEmail(string email);
        Task<PagedResults<Usuario>> GetPaginationVersion1(PaginationParams request);

        Task<PagedResults<UsuarioVm>> GetPaginationVersion2(PaginationParams request);
    }
}
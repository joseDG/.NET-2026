using Api.Data;
using Api.Dtos.Login;
using Api.Dtos.UsuarioRegister;
using Api.Models;
using Api.Models.Domain;
using Api.Pagination;
using Api.Vms;
using Firebase.Api.Pagination;
using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

    private readonly HttpClient httpClient;
    private readonly DatabaseContext context;
     private readonly IPagedList paginacion;

    public AuthenticationService(HttpClient httpClient, DatabaseContext context, IPagedList paginacion)
    {
      this.httpClient = httpClient;
      this.context = context;
      this.paginacion = paginacion;
    }

    public async Task<PagedResults<Usuario>> GetPaginationVersion1(PaginationParams request)
    {
      var query = context.Usuarios.Include(x => x.Roles)!.ThenInclude(x => x.Permisos);

        return await paginacion.CreatePagedGenericResults<Usuario>(query,
             request.PageNumber,
             request.PageSize,
             request.OrderBy!,
             request.OrderAsc
         );
    }

    public async Task<PagedResults<UsuarioVm>> GetPaginationVersion2(PaginationParams request)
    {
               var query = context.Database.SqlQuery<UsuarioVm>(@$"
                    SELECT 
                    usr.""Id"",
                    usr.""Email"",
                    usr.""FullName"",
                    string_agg(rol.""Name"", ',') as ""Role"",
                    string_agg(perm.""Nombre"", ',') as ""Permiso""
                    FROM ""Usuarios"" as usr
                    LEFT JOIN ""UsuarioRole"" as usrol
                        ON usr.""Id""=usrol.""UsuarioId""
                    LEFT JOIN ""Roles"" as rol
                        ON rol.""Id""=usrol.""RoleId""
                    LEFT JOIN ""RolePermiso"" as rolePermiso
                        ON rolePermiso.""RoleId"" = rol.""Id""
                    LEFT JOIN ""Permisos"" as perm
                        ON perm.""Id"" = rolePermiso.""PermisoId""
                    Group By usr.""Id""
                  ");

                return await paginacion.CreatePagedGenericResults(
                    query,
                    request.PageNumber,
                    request.PageSize,
                    request.OrderBy!,
                    request.OrderAsc
                    );
    }

    public async Task<Usuario?> GetUserByEmail(string email)
    {
      return await context.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();
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

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("Credenciales erroneas");        
        }

        var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();

        return authFirebaseObject!.IdToken!;
    }

    public async Task<string> RegisterAsync(UsuarioRegisterRequestDto request)
        {
            var userArgs = new UserRecordArgs()
            { 
                DisplayName = request.FullNombre,
                Email = request.Email,
                Password = request.Password
            };

            var usuario = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

            //neuva funcionalidad para con la tabla de usuarios
            context.Usuarios.Add(new Usuario
            {
               Email = request.Email,
               FullName = request.FullNombre,
               FirebaseId = usuario.Uid 
            });

            await context.SaveChangesAsync();

            return usuario.Uid;
        }
    }
}
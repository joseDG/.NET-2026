using Api.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Api.Authentication
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(PermisoEnum permiso): base(policy: permiso.ToString())
        {
        }
    }
}
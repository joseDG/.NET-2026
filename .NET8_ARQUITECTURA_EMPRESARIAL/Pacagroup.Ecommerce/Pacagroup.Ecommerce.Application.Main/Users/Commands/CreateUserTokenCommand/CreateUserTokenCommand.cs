using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
    public sealed record CreateUserTokenCommand : IRequest<Response<UserDto>>
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}

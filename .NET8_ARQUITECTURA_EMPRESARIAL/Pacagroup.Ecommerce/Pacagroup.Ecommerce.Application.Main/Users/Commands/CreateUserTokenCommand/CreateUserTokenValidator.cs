using FluentValidation;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
    public class CreateUserTokenValidator : AbstractValidator<CreateUserTokenCommand>
    {
        public CreateUserTokenValidator()
        {
            RuleFor(u => u.userName).NotNull().NotEmpty();
            RuleFor(u => u.password).NotNull().NotEmpty().MinimumLength(5);
        }
    }
}

using Bogus;
using FluentValidation;

namespace MasterNet.Application.Accounts.Register;


public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty()
        .WithMessage("El Email no es correcto");
        
        RuleFor(x => x.Password).NotEmpty()
        .WithMessage("El password esta en blanco");
        
        RuleFor(x => x.NombreCompleto).NotEmpty()
        .WithMessage("El nombre es nulo");
        
        RuleFor(x => x.Carrera).NotEmpty().WithMessage("La carrera esta en blanco");

        RuleFor(x => x.Username).NotEmpty().WithMessage("Ingrese un username");
    }
}
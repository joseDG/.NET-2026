using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MasterNet.Application.Cursos.CursoUpdate;

public class CursoUpdateValidator
: AbstractValidator<CursoUpdateRequest>
{
    public CursoUpdateValidator()
    {
        RuleFor(x => x.Titulo).NotEmpty()
        .WithMessage("El titulo no debe ser vacio");

        RuleFor(x => x.Descripcion).NotEmpty()
        .WithMessage("La descripcion no debe esta vacia");

        RuleFor(x => x.FechaPublicacion).Must(ValidateDateTime)
        .WithMessage("Error en la fecha de publicacion");
    }

    private bool ValidateDateTime(DateTime? date)
    {
        if (date == null) return false;
        if (date == default(DateTime))
            return false;
        return true;
    }
}
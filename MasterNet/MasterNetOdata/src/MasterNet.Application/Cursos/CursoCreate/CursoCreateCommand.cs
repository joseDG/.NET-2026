// Command
// CommandHandler

using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Domain.Abstractions;
using MediatR;

namespace MasterNet.Application.Cursos.CursoCreate;

/// <summary>
/// Command for creating a new Curso.
/// </summary>
public class CursoCreateCommand
{
    /// <summary>
    /// Request object for creating a new Curso.
    /// </summary>
    /// <param name="cursoCreateRequest">The details of the Curso to be created.</param>
    /// <returns>A result containing the ID of the created Curso.</returns>
    public record CursoCreateCommandRequest(CursoCreateRequest cursoCreateRequest)
    : IRequest<Result<Guid>>, ICommandBase;

    /// <summary>
    /// Handler for processing the CursoCreateCommandRequest.
    /// </summary>
    internal class CursoCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        /// <summary>
        /// Initializes a new instance of the CursoCreateCommandHandler class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        /// <param name="photoService">The photo service for handling photo uploads.</param>
        public CursoCreateCommandHandler(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        /// <summary>
        /// Handles the CursoCreateCommandRequest.
        /// </summary>
        /// <param name="request">The request object containing the details of the Curso to be created.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A result containing the ID of the created Curso.</returns>
        public async Task<Result<Guid>> Handle(CursoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var cursoId = Guid.NewGuid();
            var curso = new Curso
            {
                Id = cursoId,
                Titulo = request.cursoCreateRequest.Titulo,
                Descripcion = request.cursoCreateRequest.Descripcion,
                FechaPublicacion = request.cursoCreateRequest.FechaPublicacion
            };

            if (request.cursoCreateRequest.Foto is not null)
            {
                var photoUploadResult = await _photoService.AddPhoto(request.cursoCreateRequest.Foto);
                var photo = new Photo
                {
                    Id = Guid.NewGuid(),
                    Url = photoUploadResult.Url,
                    PublicId = photoUploadResult.PublicId,
                    CursoId = cursoId
                };
                curso.Photos = new List<Photo> { photo };
            }

            if (request.cursoCreateRequest.InstructorId is not null)
            {
                var instructor = await _unitOfWork.Repository<Instructor>().GetByIdAsync(request.cursoCreateRequest.InstructorId.Value);
                if (instructor is null)
                {
                    return Result<Guid>.Failure("No se encontró el instructor");
                }
                curso.Instructores = new List<Instructor> { instructor };
            }

            if (request.cursoCreateRequest.PrecioId is not null)
            {
                var precio = await _unitOfWork.Repository<Precio>().GetByIdAsync(request.cursoCreateRequest.PrecioId.Value);
                if (precio is null)
                {
                    return Result<Guid>.Failure("No se encontró el precio");
                }
                curso.Precios = new List<Precio> { precio };
            }

            await _unitOfWork.Repository<Curso>().AddAsync(curso);
            var resultado = await _unitOfWork.SaveChangesAsync();

            return resultado ? Result<Guid>.Success(curso.Id) : Result<Guid>.Failure("No se pudo insertar el curso");
        }
    }

    /// <summary>
    /// Validator for CursoCreateCommandRequest.
    /// </summary>
    public class CursoCreateCommandRequestValidator
    : AbstractValidator<CursoCreateCommandRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CursoCreateCommandRequestValidator class.
        /// </summary>
        public CursoCreateCommandRequestValidator()
        {
            RuleFor(x => x.cursoCreateRequest).SetValidator(new CursoCreateValidator());
        }
    }
}

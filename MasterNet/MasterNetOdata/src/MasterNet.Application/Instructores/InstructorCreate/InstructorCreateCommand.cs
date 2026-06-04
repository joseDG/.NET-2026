using MasterNet.Domain;
using MasterNet.Domain.Abstractions;
using MediatR;


namespace MasterNet.Application.Instructores.InstructorCreate
{
    public class InstructorCreateCommand
    {
        public class InstructorCreateCommandRequest : IRequest<Guid>
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
        }

        public class InstructorCreateCommandHandler : IRequestHandler<InstructorCreateCommandRequest, Guid>
        {
            private readonly IUnitOfWork _unitOfWork;

            public InstructorCreateCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Guid> Handle(InstructorCreateCommandRequest request, CancellationToken cancellationToken)
            {
                var instructor = new Instructor
                {
                    Nombre = request.FirstName,
                    Apellidos = request.LastName,
                    // Assuming Email is a property in Instructor, if not, you can add it to the Instructor class
                    // Email = request.Email
                };

                var instructorRepository = _unitOfWork.Repository<Instructor>();
                await instructorRepository.AddAsync(instructor);
                await _unitOfWork.SaveChangesAsync();

                return instructor.Id;
            }
        }
    }
}

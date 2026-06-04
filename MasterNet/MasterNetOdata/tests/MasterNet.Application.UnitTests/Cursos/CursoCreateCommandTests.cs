using MasterNet.Application.Cursos.CursoCreate;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Domain.Abstractions;
using Moq;
using static MasterNet.Application.Cursos.CursoCreate.CursoCreateCommand;

namespace MasterNet.Application.UnitTests.Cursos;
public class CursoCreateCommandTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IPhotoService> _mockPhotoService;
    private readonly CursoCreateCommandHandler _handler;

    public CursoCreateCommandTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockPhotoService = new Mock<IPhotoService>();
        _handler = new CursoCreateCommandHandler(_mockUnitOfWork.Object, _mockPhotoService.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnSuccessResult_WhenCursoIsCreated()
    {
        // Arrange
        var request = new CursoCreateCommandRequest(new CursoCreateRequest
        {
            Titulo = "Test Curso",
            Descripcion = "Test Descripcion",
            FechaPublicacion = DateTime.UtcNow
        });

        _mockUnitOfWork.Setup(uow => uow.Repository<Curso>().AddAsync(It.IsAny<Curso>())).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        _mockUnitOfWork.Verify(uow => uow.Repository<Curso>().AddAsync(It.IsAny<Curso>()), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnFailureResult_WhenInstructorNotFound()
    {
        // Arrange
        var request = new CursoCreateCommandRequest(new CursoCreateRequest
        {
            Titulo = "Test Curso",
            Descripcion = "Test Descripcion",
            FechaPublicacion = DateTime.UtcNow,
            InstructorId = Guid.NewGuid()
        });

        _mockUnitOfWork.Setup(uow => uow.Repository<Instructor>().GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Instructor)null);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("No se encontró el instructor", result.Error);
    }

    [Fact]
    public async Task Handle_ShouldReturnFailureResult_WhenPrecioNotFound()
    {
        // Arrange
        var request = new CursoCreateCommandRequest(new CursoCreateRequest
        {
            Titulo = "Test Curso",
            Descripcion = "Test Descripcion",
            FechaPublicacion = DateTime.UtcNow,
            PrecioId = Guid.NewGuid()
        });

        _mockUnitOfWork.Setup(uow => uow.Repository<Precio>().GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Precio)null);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("No se encontró el precio", result.Error);
    }
}

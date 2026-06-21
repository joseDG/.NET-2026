
using System.ComponentModel.DataAnnotations.Schema;

namespace CP.Portal.Movies.Module.Data;

internal class Movie
{
    public Guid MovieId { get; private set; } = Guid.CreateVersion7();
    public string Title { get; private set; } = string.Empty;
    public string? OriginalTitle { get; private set; } 
    public string? Synopsis { get; private set; }
    public DateOnly ReleaseYear { get; private set; }
    public int DurationMinutes { get; private set; }
    public string? Language { get; private set; }
    public decimal RentalPrice { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    //Relaciones
    public ICollection<MovieCast> Casts { get; } = [];
    public ICollection<MovieCrew> Crewers { get; } = [];
    public ICollection<MovieGenre> MovieGenres { get; } = [];

    //projections
    [NotMapped]
    public IEnumerable<Genre> Genres => MovieGenres.Select(g => g.Genre!).Where(g => g is not null);

    [NotMapped]
    public IEnumerable<Person> CastPeople => Casts.Select(c => c.Person!).Where(g => g is not null);


    [NotMapped]
    public IEnumerable<Person> CrewPeople => Crewers.Select(c => c.Person!).Where(g => g is not null);



    //Crear constructor
    internal Movie(string title, DateOnly releaseYear, int durationMinutes, string language, decimal rentalPrice, string? originalTitle = null, string? synopsis = null) 
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException("Title cannot be null, empty or whitespace", nameof(title));

        if (synopsis is not null && synopsis.Length > 4000)
            throw new ArgumentException("Synopsis exceeds maximum lenght (4000)", nameof(synopsis));

        if (rentalPrice < 0m)
            throw new ArgumentOutOfRangeException(nameof(rentalPrice), "RentalPrice cannot be negative");

        Title = title.Trim();
        OriginalTitle = originalTitle?.Trim();
        Synopsis = synopsis?.Trim();
        ReleaseYear = releaseYear;
        DurationMinutes = durationMinutes;
        Language = language.Trim();
        RentalPrice = rentalPrice;
    }

}

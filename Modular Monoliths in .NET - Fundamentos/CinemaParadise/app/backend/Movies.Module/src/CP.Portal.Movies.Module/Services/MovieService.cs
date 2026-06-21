using CP.Portal.Movies.Module.Endpoints;

namespace CP.Portal.Movies.Module.Services;

internal class MovieService : IMovieService
{
     public List<MovieResponse> GetMovies()
     {
          return new List<MovieResponse>
          {
               new MovieResponse(Guid.NewGuid(), "Matriz", "Best movie of the year"),
               new MovieResponse(Guid.NewGuid(), "Mad Max", "Furist"),
               new MovieResponse(Guid.NewGuid(), "Kun fu", "Asia")
          };
     }
}


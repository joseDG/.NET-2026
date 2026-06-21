using CP.Portal.Movies.Module.Services;

using FastEndpoints;

namespace CP.Portal.Movies.Module.Endpoints;

internal class ListMoviesEndpoint(IMovieService movieService) : EndpointWithoutRequest<ListMoviesResponse>
{
    private readonly IMovieService movieService = movieService;

    public override void Configure()
    {
        Get("/api/movies");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var movies =  this.movieService.GetMovies();

        var response = new ListMoviesResponse()
        {
            Movies = movies
        };

        await Send.OkAsync(response);
    }
}

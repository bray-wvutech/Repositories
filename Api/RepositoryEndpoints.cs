using Assignment3.Data;
using Assignment3.Models;

namespace Api;

public static class RepositoryEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet("/movies", GetMovies);
        app.MapDelete("/movie/{id}", DeleteMovieAsync);
    }

    // this is the most minimal version of this function
    // notice we pass in the repository which gets created for us
    // by the dependency injection system
    public static IEnumerable<Movie> GetMovies(IMovieRepository repo)
    {
        return repo.GetMovies();
    }

    // here is a version that returns an IResult
    // this adds in returning standard web codes for problems
    public static IResult BetterGetMovies(IMovieRepository repo)
    {
        try
        {
            return Results.Ok(repo.GetMovies());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    // I am also including deleting a movie
    // so you can see one that takes a parameter in
    // and just returns whether or not it succeeded
    public static async Task<IResult> DeleteMovieAsync(IMovieRepository repo, int id)
    {
        try
        {
            Movie? movie = await repo.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return Results.NotFound();
            }

            await repo.DeleteMovieAsync(movie);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }
}

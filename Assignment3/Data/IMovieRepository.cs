using Assignment3.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Assignment3.Data;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();

    // I am doing a couple async examples
    // note however you don't put async keyword on the stubs
    public Task<Movie?> GetMovieByIdAsync(int id);

    // I am doing a couple async examples
    // note however you don't put async keyword on the stubs
    public Task DeleteMovieAsync(Movie movie);

    //IEnumerable<Movie> GetMovies(string search, string genre);
    //void Create(Movie movie);
}

using Assignment3.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Assignment3.Data;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    //IEnumerable<Movie> GetMovies(string search, string genre);
    bool Delete(int id);
    void Create(Movie movie);
}

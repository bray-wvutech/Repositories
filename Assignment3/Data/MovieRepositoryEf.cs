using Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Data;

public class MovieRepositoryEf : IMovieRepository
{
    private readonly Assignment3Context _context;

    public MovieRepositoryEf(Assignment3Context context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _context.Movie.ToList();
    }

    public async Task<Movie?> GetMovieByIdAsync(int id) =>
        await _context.Movie.FirstOrDefaultAsync(i => i.Id == id);

    public async Task DeleteMovieAsync(Movie movie)
    {
        _context.Movie.Remove(movie);
        await _context.SaveChangesAsync();
    }
}

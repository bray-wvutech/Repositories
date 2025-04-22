using Assignment3.Models;

namespace Assignment3.Data;

public class MovieRepositoryList : IMovieRepository
{
    private List<Movie> _movieList = new List<Movie>();

    public MovieRepositoryList()
    {
        Movie movie1 = new Movie();
        movie1.Price = 1.23m;
        movie1.Title = "Movie 1";
        movie1.ReleaseDate = DateTime.Now;
        movie1.Id = 1;

        Movie movie2 = new Movie();
        movie2.Price = 4.56m;
        movie2.Title = "Movie 2";
        movie2.ReleaseDate = DateTime.Now;
        movie2.Id = 2;

        _movieList.Add(movie1);
        _movieList.Add(movie2);
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _movieList.ToList();
    }

    // our in memory list does not have async functions
    // so we have to do a non-async version
    // and manually return the Task object
    public Task<Movie?> GetMovieByIdAsync(int id)
    {
        return Task.FromResult(_movieList.FirstOrDefault(m => m.Id == id));
    }

    // our in memory list does not have async functions
    // so we have to do a non-async version
    // and manually return the Task object
    public Task DeleteMovieAsync(Movie movie)
    {
        _movieList.Remove(movie);
        return Task.CompletedTask;
    }
}

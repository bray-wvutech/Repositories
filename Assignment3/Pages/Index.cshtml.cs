using Assignment3.Data;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMovieRepository _repo;

    public IEnumerable<Movie> Movies { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IMovieRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public void OnGet()
    {
        Movies = _repo.GetMovies();
    }
}

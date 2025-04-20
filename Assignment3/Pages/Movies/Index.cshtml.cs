using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;

namespace Assignment3.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Assignment3.Data.Assignment3Context _db;

        public IndexModel(Assignment3.Data.Assignment3Context context)
        {
            _db = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty]
        public string? Search { get; set; }

        public void OnGet()
        {
            //Movie = _context.Movie.Where(m => m.Title.Contains("Pad")).ToList();
            Movie = _db.Movie.ToList();
            //Movie = _db.Movie.Where(film => film.Price > 10).ToList();
        }

        public void OnPost()
        {
            //if (!string.IsNullOrEmpty(Search))
            //{
            //    Movie = _db.Movie.Where(m => m.Title.Contains(Search)).ToList();
            //}
            //else
            //{
                Movie = _db.Movie.ToList();
            //}
        }
    }
}

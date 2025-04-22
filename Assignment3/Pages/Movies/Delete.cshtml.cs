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
    public class DeleteModel : PageModel
    {
        private readonly IMovieRepository _repo;

        public DeleteModel(IMovieRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repo.GetMovieByIdAsync(id.Value);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repo.GetMovieByIdAsync(id.Value);
            if (movie != null)
            {
                Movie = movie;
                await _repo.DeleteMovieAsync(Movie);
            }

            return RedirectToPage("./Index");
        }
    }
}

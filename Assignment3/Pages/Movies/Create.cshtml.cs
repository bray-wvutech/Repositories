using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment3.Data;
using Assignment3.Models;
using Assignment3.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace Assignment3.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Assignment3.Data.Assignment3Context _context;
        // we need this environment variable to get folder location values from
        // we use those to build an absolute path to save our uploaded image files to
        // we get it through the constructor using dependency injection
        private readonly IWebHostEnvironment _env;

        public CreateModel(Assignment3.Data.Assignment3Context context, 
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // here is where we are dealing with the image file
            // HttpContext is a built in object we have access to
            // it has a Request object that has all kinds of info
            // about the request that got us here in the OnPost
            // including information about the form that submitted the request
            // the Form object has a list of Files
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                // PictureUri is the model property where we are storing
                // the path to our image

                // PictureHelper.UploadNewImage is a utility function
                // written by us to take an environment variable
                // and a file and rename the file and place it in a
                // specific folder then return a path to it

                Movie.Image = PictureHelper.UploadNewImage(_env,
                    HttpContext.Request.Form.Files[0]);
            }

            _context.Movie.Add(Movie);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}

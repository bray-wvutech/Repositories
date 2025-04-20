
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment3.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

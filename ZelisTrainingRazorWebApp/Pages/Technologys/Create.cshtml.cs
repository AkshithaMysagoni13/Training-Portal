using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologys
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Technology Technology { get; set; }

        ITechnologyRepository repo = new ADOTechnologyRepository();

        public void OnGet() { }

        public IActionResult OnPost()
        {

            repo.Add(Technology);
            return RedirectToPage("/Technologys/Index");
        }
    }
}

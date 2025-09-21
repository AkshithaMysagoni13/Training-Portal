using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer { get; set; }

        ITrainerRepository repo = new ADOTrainerRepository();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            repo.Add(Trainer);
            return RedirectToPage("/Trainers/Index");
        }
    }
}

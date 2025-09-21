using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Trainer trainer { get; set; }

        static int trainerId;
        ITrainerRepository repo = new ADOTrainerRepository();

        public void OnGet(int id)
        {
            trainerId = id;
            trainer = repo.GetById(id);
        }

        public IActionResult OnPost()
        {
            repo.Update(trainer, trainerId);
            return RedirectToPage("/Trainers/Index");
        }
    }
}

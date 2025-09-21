using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class DeleteModel : PageModel
    {
        public Trainer Trainer { get; set; }

        static int trainerId;
        ITrainerRepository repo = new ADOTrainerRepository();

        public void OnGet(int id)
        {
            trainerId = id;
            Trainer = repo.GetById(id);
        }

        public IActionResult OnPost()
        {
            repo.Delete(trainerId);
            return RedirectToPage("/Trainers/Index");
        }
    }
}

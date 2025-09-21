using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Training Training { get; set; }
        ITrainingRepository repo = new ADOTrainingRepository();
        static int trainingId;

        public void OnGet(int id)
        {
            trainingId = id;
            Training = repo.GetById(id);
        }

        public IActionResult OnPost()
        {
            repo.Update(Training, trainingId);
            return RedirectToPage("/Trainings/Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Trainee trainee { get; set; }

        ITraineeRepository repo = new ADOTraineeRepository();

        public void OnGet(int trainingId, int employeeId)
        {
            trainee = repo.GetById(trainingId, employeeId);
        }

        public IActionResult OnPost()
        {
            repo.Update(trainee, trainee.TrainingId, trainee.EmpId);
            return RedirectToPage("/Trainees/Index");
        }
    }
}

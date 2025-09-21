using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DetailsModel : PageModel
    {
        public Trainee trainee { get; set; }
        ITraineeRepository repo = new ADOTraineeRepository();

        public void OnGet(int trainingId, int employeeId)
        {
            trainee = repo.GetById(trainingId, employeeId);
        }
    }
}

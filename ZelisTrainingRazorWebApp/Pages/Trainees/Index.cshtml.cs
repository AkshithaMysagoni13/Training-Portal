using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class IndexModel : PageModel
    {
        public List<Trainee> Trainees = new();
        ITraineeRepository repo = new ADOTraineeRepository();

        public void OnGet()
        {
            Trainees = repo.GetAll();
        }

    }
}

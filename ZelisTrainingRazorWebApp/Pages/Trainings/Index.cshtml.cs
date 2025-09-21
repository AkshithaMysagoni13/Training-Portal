using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        public List<Training> Trainings = new List<Training>();
        ITrainingRepository repo = new ADOTrainingRepository();

        public void OnGet()
        {
            Trainings = repo.GetAlltrainings();
        }
    }
}

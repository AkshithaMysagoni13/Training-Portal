using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class IndexModel : PageModel
    {
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
        ITrainerRepository repo = new ADOTrainerRepository();

        public void OnGet()
        {
            Trainers = repo.GetAlltrainers();
        }
    }
}

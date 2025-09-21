using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        public Training Training { get; set; }
        ITrainingRepository repo = new ADOTrainingRepository();

        public void OnGet(int id)
        {
            Training = repo.GetById(id);
        }
    }
}

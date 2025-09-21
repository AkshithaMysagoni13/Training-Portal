using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        public Trainer Trainer { get; set; }
        ITrainerRepository repo = new ADOTrainerRepository();

        public void OnGet(int id)
        {
            Trainer = repo.GetById(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologys
{
    public class DetailsModel : PageModel
    {
        public Technology Technology { get; set; }
        ITechnologyRepository repo = new ADOTechnologyRepository();

        public void OnGet(int id)
        {
            Technology = repo.GetById(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologys
{
    public class IndexModel : PageModel
    {
        public List<Technology> Technologies = new List<Technology>();
        ITechnologyRepository repo = new ADOTechnologyRepository();

        public void OnGet()
        {
            Technologies = repo.GetAlltechnologies();
        }
    }
}

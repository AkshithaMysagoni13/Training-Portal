using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologys
{
    public class DeleteModel : PageModel
    {
        public Technology Technology { get; set; }
        ITechnologyRepository repo = new ADOTechnologyRepository();
        static int techId;

        public void OnGet(int id)
        {
            techId = id;
            Technology = repo.GetById(id);
        }

        public IActionResult OnPost()
        {
            repo.Delete(techId);
            return RedirectToPage("/Technologys/Index");
        }
    }
}

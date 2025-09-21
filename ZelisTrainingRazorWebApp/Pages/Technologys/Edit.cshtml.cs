using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologys
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Technology technology { get; set; }

        ITechnologyRepository repo = new ADOTechnologyRepository();
        static int technologyId;

        public void OnGet(int id)
        {
            technologyId = id;
            technology = repo.GetById(id);
        }

        public IActionResult OnPost()
        {
            repo.Update(technology, technologyId);
            return RedirectToPage("/Technologys/Index");
        }
    }
}

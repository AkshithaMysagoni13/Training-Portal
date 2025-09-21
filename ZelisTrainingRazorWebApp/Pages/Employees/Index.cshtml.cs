using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;


namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {

        public List<Employee> employees = new List<Employee>();
        IEmployeeRepository repo = new ADOEmployeeRepository();

        public void OnGet()
        {
            employees = repo.GetAllEmployees();

        }
    }
}

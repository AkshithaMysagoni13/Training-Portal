using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        public Employee Employee { get; set; }

        IEmployeeRepository repo = new ADOEmployeeRepository();
        static int empId;

        public void OnGet(int id)
        {
            empId = id;
            Employee = repo.GetEmployeeById(id);
        }

        public IActionResult OnPost()
        {
            repo.DeleteEmployee(empId);
            return RedirectToPage("/Employees/Index");
        }
    }
}

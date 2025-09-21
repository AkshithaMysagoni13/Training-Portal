using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }

        private readonly IEmployeeRepository repo = new ADOEmployeeRepository();

        
        public void OnGet(int empid)
        {
            Employee = repo.GetEmployeeById(empid);
        }

        
        public IActionResult OnPost()
        {
            repo.UpdateEmployee(Employee.EmpId, Employee);
            return RedirectToPage("/Employees/Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;

namespace ZelisTrainingLibrary.Repos
{
    public interface IEmployeeRepository
    {
        void InsertEmployee(Employee employee);
        void UpdateEmployee(int eid, Employee employee);
        void DeleteEmployee(int eid);
        List<Employee> GetAllEmployees();
         
        Employee GetEmployeeById(int eid);
    }
}

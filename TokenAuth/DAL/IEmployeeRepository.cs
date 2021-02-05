using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAuth.Models;

namespace TokenAuth.DAL
{
    interface IEmployeeRepository
    {
        List<Employee> DisplayEmployees();
        Employee SearchEmployeeByID(int ID);
        Employee SearchEmployeeByName(string Name);
        Employee Login(string Email, string Password);
        bool InsertEmployee(Employee OurEmployee);
        bool UpdateEmployee(Employee OurEmployee);
        bool DeleteEmployee(int ID);
    }
}

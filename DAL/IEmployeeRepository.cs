using Employee_mvc_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_mvc_webapi.DAL
{
    public interface IEmployeeRepository
    {
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(string id);
        Employee GetEmployee(string id);
        List<Employee> GetEmployees();
       
    }

   
}

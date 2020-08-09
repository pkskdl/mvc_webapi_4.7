using Employee_mvc_webapi.DAL;
using Employee_mvc_webapi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employee_mvc_webapi.Controllers.api
{
    public class EmployeesApiController : ApiController
    {
        private readonly IEmployeeRepository _iEmployeeRepository = new EmployeeRepository();

        [HttpGet]
        [Route("api/Employees/Get")]
        public  List<Employee> Get()
        {
            return  _iEmployeeRepository.GetEmployees();
        }

        [HttpPost]
        [Route("api/Employees/Create")]
        public bool  Get([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
               return  _iEmployeeRepository.Add(employee);
            }
            else
            {
                return false;
            }
        }

      

        [HttpGet]
        [Route("api/Employees/Details/{id}")]
        public  Employee Details(string id)
        {
            var result =  _iEmployeeRepository.GetEmployee(id);
            return result;
        }

        [HttpPut]
        [Route("api/Employees/Edit")]
        public bool  Edit([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                return _iEmployeeRepository.Update(employee);
            }
            else
            {
                return false;
            }
        }

       

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public bool DeleteConfirmed(string id)
        {
            return _iEmployeeRepository.Delete(id);
        }
    }
}

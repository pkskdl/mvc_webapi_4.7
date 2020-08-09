using Dapper;
using Employee_mvc_webapi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Employee_mvc_webapi.DAL
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly IDbConnection _db;
        
        public EmployeeRepository()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        bool IEmployeeRepository.Add(Employee employee)
        {
            int rowsAffected = this._db.Execute(@"INSERT Employee([FirstName],[LastName],[Emailid],[Address],[Gender],[Company],[Designation]) 

values (@FirstName,@LastName,@Emailid, @Address, @Gender,@Company,@Designation)",
                        new {
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Emailid = employee.Emailid,
                            Address = employee.Address,
                            Gender = employee.Gender,
                            Company = employee.Company,
                            Designation = employee.Designation
 });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        bool IEmployeeRepository.Delete(string id)
        {
           
           
            int rowsAffected = this._db.Execute(@"DELETE FROM [Employee] WHERE Empid = @Empid",
                new { Empid = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        Employee IEmployeeRepository.GetEmployee(string id)
        {
            return _db.Query<Employee>("SELECT * FROM [Employee] WHERE Empid =@Empid", new { Empid = id }).SingleOrDefault();
        }

        List<Employee> IEmployeeRepository.GetEmployees()
        {
            return _db.Query<Employee>("SELECT *  FROM [Employee]  ").ToList();
        }

        

        bool IEmployeeRepository.Update(Employee employee)
        {
            int rowsAffected = this._db.Execute(
   "UPDATE [Employee] SET [FirstName] = @FirstName ,[LastName]=@LastName,[Emailid]=@Emailid,[Address] = @Address, [Gender] = @Gender,[Company]=@Company,Designation=@Designation WHERE Empid = " +
                        employee.Empid, employee);

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;


  
        }
    }
}
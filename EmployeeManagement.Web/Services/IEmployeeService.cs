using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeManagement.Model;

namespace EmployeeManagement.Web.Services
{
  public  interface IEmployeeService
    {

        
Task<IEnumerable<Employee>> GetEmployee();

        Task<Employee> GetEmployee(int id);

        Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee);

        Task<HttpResponseMessage> CreateEmployee(Employee NewEmployee);

        Task DeleteEmployee(int id);
        
           
        }

    }







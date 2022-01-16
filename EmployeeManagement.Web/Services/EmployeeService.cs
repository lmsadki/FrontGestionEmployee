using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
          private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateEmployee(Employee NewEmployee)
        {
            return await httpClient.PostAsJsonAsync<Employee>("api/employees", NewEmployee);
        }

        public  async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee)
        {

            return await httpClient.PutAsJsonAsync<Employee>($"api/employees/{updatedEmployee.EmployeeId}", updatedEmployee);
        }


     


    }
}



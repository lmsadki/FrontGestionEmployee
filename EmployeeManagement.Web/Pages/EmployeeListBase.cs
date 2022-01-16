using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Model;
using EmployeeManagement.Web.Services;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; } = new Employee();
        [Inject]
        public NavigationManager NavigationManager { get; set;} 
        protected override async Task OnInitializedAsync()
        {
            Employees = new List<Employee>();
            Employees = (await EmployeeService.GetEmployee()).ToList();
        }

        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavigationManager.NavigateTo("/");
        }

    }
    }





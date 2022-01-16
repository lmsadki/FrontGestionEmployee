using EmployeeManagement.Model;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class CreateEmployeeBase : ComponentBase 
    {

        [Inject]
    
       public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } = new Employee();
    [Inject]
    public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Employee = new Employee
            {
                DepartementId = 1,
                DateOfBrith = DateTime.Now,
                PhotoPath = "image/nophoto.jpg"
            };
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartementId.ToString();
        }
        protected async Task HandleValidSubmit()
        {
            Employee.DepartementId = int.Parse(DepartmentId);
            var result = await EmployeeService.CreateEmployee(Employee);
            if(result != null){

                NavigationManager.NavigateTo("/");
            }
        }
    }

}

using BethanysPieShopBlazor.Services;
using BethanysPieShopBlazor.Shared;
using Microsoft.AspNetCore.Components;


namespace BethanysPieShopBlazor.Pages
{
    public partial class EmployeeOverview
    {
        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }
    }
}
using BethanysPieShopBlazor.Services;
using BethanysPieShopBlazor.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopBlazor.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        }
    }
}

      
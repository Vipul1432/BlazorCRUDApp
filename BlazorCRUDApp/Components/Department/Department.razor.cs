using BlazorCRUDApp.Dtos;
using BlazorCRUDApp.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Components.Department
{
    public class DepartmentList : ComponentBase
    {
        [Inject]
        private DepartmentService DepartmentService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public List<DepartmentDto> Departments = new List<DepartmentDto>();

        protected override async Task OnInitializedAsync()
        {
            Departments = await DepartmentService.GetAllDepartmentsAsync();
        }

        protected void CreateDepartment()
        {
            NavigationManager.NavigateTo("/department/new");
        }

        protected void EditDepartment(int id)
        {
            NavigationManager.NavigateTo($"/department/{id}");
        }

        protected async Task DeleteDepartment(int id)
        {
            await DepartmentService.DeleteDepartmentAsync(id);
            Departments = await DepartmentService.GetAllDepartmentsAsync();
        }
    }
}

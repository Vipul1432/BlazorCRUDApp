using BlazorCRUDApp.Dtos;
using BlazorCRUDApp.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUDApp.Components.Department
{
    public class DepartmentAddEdit : ComponentBase
    {
        [Parameter] public int? Id { get; set; }
        public DepartmentDto Department { get; set; }
     
        public string Title => Id.HasValue ? "Edit Department" : "Add Department";
        public string SubmitButtonText => Id.HasValue ? "Update" : "Create";

        [Inject] private DepartmentService DepartmentService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id.HasValue)
            {
                Department = await DepartmentService.GetDepartmentByIdAsync(Id.Value);
            }
            else
            {
                Department = new DepartmentDto();
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Id.HasValue)
            {
                await DepartmentService.UpdateDepartmentAsync(Id.Value, Department.Name);
            }
            else
            {
                await DepartmentService.AddDepartmentAsync(Department);
            }

            NavigationManager.NavigateTo("/department");
        }
    }
}

using BlazorCRUDApp.Dtos;

namespace BlazorCRUDApp.Services
{
    public class DepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DepartmentDto>>("api/department");
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<DepartmentDto>($"api/department/{id}");
        }

        public async Task AddDepartmentAsync(DepartmentDto department)
        {
            await _httpClient.PostAsJsonAsync("api/department", department);
        }

        public async Task UpdateDepartmentAsync(int id, string name)
        {
            await _httpClient.PutAsJsonAsync($"api/department/{id}", name);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/department/{id}");
        }
    }

}

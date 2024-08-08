using System.Text.Json.Serialization;

namespace BlazorCRUDApp.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        [JsonPropertyName("departmentName")]
        public string Name { get; set; }
    }
}

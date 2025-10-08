using System.Net.Http.Json;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _http;
    private const string AccountName = "edubuddydata";

    public EmployeeService(HttpClient http)
    {
        _http = http;
    }

    public async Task<Employee?> GetEmployeeAsync(int employeeId)
    {
        return await _http.GetFromJsonAsync<Employee>($"api/employee/{employeeId}");
    }

    public string GetStaffPhotoUrl(int staffId, int schoolId)
    {
        string schoolContainerName = schoolId == 1 ? "data" : $"school-{schoolId}";
        string baseUrl = $"https://{AccountName}.blob.core.windows.net";
        return $"{baseUrl}/{schoolContainerName}/staff-pics/{staffId}.jpg";
    }

    public async Task<EmployeeBasicAPIDetailsDto?> GetEmployeeBasicAsync(int employeeId)
    {
        return await _http.GetFromJsonAsync<EmployeeBasicAPIDetailsDto>($"api/Employee/basic/{employeeId}");
    }
}

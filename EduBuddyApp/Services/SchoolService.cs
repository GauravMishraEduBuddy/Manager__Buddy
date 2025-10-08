using System.Net.Http.Json;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public class SchoolService : ISchoolService
{
    private readonly HttpClient _http;

    public SchoolService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<School>> GetSchoolsAsync()
    {
        return await _http.GetFromJsonAsync<List<School>>("api/school")
               ?? new List<School>();
    }

    public async Task<School?> GetSchoolAsync(int id)
    {
        return await _http.GetFromJsonAsync<School>($"api/school/{id}");
    }

    public string GetSchoolLogoUrl(int id)
    {
        return $"https://edubuddydata.blob.core.windows.net/logo-images/{id}.jpg";
    }

    public async Task<SchoolBasicViewModel?> GetBasicSchoolAsync(int schoolId)
    {
        try
        {
            var url = $"api/School/basic/{schoolId}";
            return await _http.GetFromJsonAsync<SchoolBasicViewModel>(url);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching basic school details: {ex.Message}");
            return null;
        }
    }
}

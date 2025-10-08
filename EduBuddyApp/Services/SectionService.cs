using System.Net.Http.Json;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public class SectionService : ISectionService
{
    private readonly HttpClient _http;

    public SectionService(HttpClient http)
    {
        _http = http;
    }
  
    public async Task<SectionViewModel?> GetSectionAsync(int sectionId)
    {
        try
        {
            return await _http.GetFromJsonAsync<SectionViewModel>($"api/section/{sectionId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching section data: {ex.Message}");
            return null;
        }
    }

    public async Task<SectionViewModelDetailed?> GetSectionDatasetAsync(int sectionId)
    {
        try
        {
            return await _http.GetFromJsonAsync<SectionViewModelDetailed>($"api/section/dataset/{sectionId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching section dataset: {ex.Message}");
            return null;
        }
    }

    public async Task<List<StudentViewShortModel>?> GetStudentsInSectionAsync(int sectionId, CancellationToken ct = default)
    {
        try
        {
            return await _http.GetFromJsonAsync<List<StudentViewShortModel>>($"api/section/{sectionId}/students", ct);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching students for section {sectionId}: {ex.Message}");
            return null;
        }
    }
}
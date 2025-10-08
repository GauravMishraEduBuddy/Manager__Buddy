using System.Net.Http.Json;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public class SyllabusService : ISyllabusService
{
    private readonly HttpClient _http;

    public SyllabusService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<SyllabusItem>> GetSubjectSyllabusAsync(int subjectId)
    {
        try
        {
            return await _http.GetFromJsonAsync<List<SyllabusItem>>($"api/Subject/syllabusitems/{subjectId}")
                  ?? new List<SyllabusItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching syllabus data: {ex.Message}");
            return new List<SyllabusItem>();
        }
    }

    public async Task<ChaptersViewModel?> GetChapterAsync(int chapterId)
    {
        try
        {
            var url = $"api/Subject/{chapterId}";
            var response = await _http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ChaptersViewModel>();
            }
            else
            {
                Console.WriteLine($"Error fetching chapter. Status Code: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception fetching chapter: {ex.Message}");
            return null;
        }
    }

    public async Task<List<PeriodTypeViewModel>> GetPeriodTypesAsync(int schoolId)
    {
        try
        {
            var url = $"api/Subject/period-types/{schoolId}";
            return await _http.GetFromJsonAsync<List<PeriodTypeViewModel>>(url)
                  ?? new List<PeriodTypeViewModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching period types: {ex.Message}");
            return new List<PeriodTypeViewModel>();
        }
    }

    public async Task<List<ChaptersViewModel>> GetChaptersForSubjectAsync(int subjectId)
    {
        try
        {
            var url = $"api/Chapter/chapters/{subjectId}";
            var chapters = await _http.GetFromJsonAsync<List<ChaptersViewModel>>(url);
            return chapters ?? new List<ChaptersViewModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching chapters for subject: {ex.Message}");
            return new List<ChaptersViewModel>();
        }
    }
}
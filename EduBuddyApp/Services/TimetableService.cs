using System.Net.Http.Json;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public class TimetableService : ITimetableService
{
    private readonly HttpClient _http;

    public TimetableService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TimetableDayViewModel>> GetTimetableDaysAsync(int employeeId)
    {
        try
        {
            return await _http.GetFromJsonAsync<List<TimetableDayViewModel>>($"api/Timetable/teacher/{employeeId}")
                ?? new List<TimetableDayViewModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching timetable data: {ex.Message}");
            return new List<TimetableDayViewModel>();
        }
    }
}
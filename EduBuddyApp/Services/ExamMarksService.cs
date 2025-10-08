using System.Net.Http.Json;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public class ExamMarksService : IExamMarksService
{
    private readonly HttpClient _http;

    public ExamMarksService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<StudentClassMarkDto>> GetSectionExamMarksAsync(int sectionId, int examId, CancellationToken ct = default)
    {
        try
        {
            var url = $"api/ExamMarks/{sectionId}/{examId}";
            return await _http.GetFromJsonAsync<List<StudentClassMarkDto>>(url, ct) ?? new List<StudentClassMarkDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching section exam marks: {ex.Message}");
            return new List<StudentClassMarkDto>();
        }
    }

    public async Task<List<ExamsViewModel>> GetExamsInOpenSessionAsync(int schoolId, CancellationToken ct = default)
    {
        try
        {
            var url = $"api/ExamMarks/open-session/{schoolId}";
            return await _http.GetFromJsonAsync<List<ExamsViewModel>>(url, ct) ?? new List<ExamsViewModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching exams in open session: {ex.Message}");
            return new List<ExamsViewModel>();
        }
    }

    public async Task<List<int>> GetExamIdsInOpenSessionAsync(int schoolId, CancellationToken ct = default)
    {
        try
        {
            var url = $"api/ExamMarks/open-session/{schoolId}/exam-ids";
            return await _http.GetFromJsonAsync<List<int>>(url, ct) ?? new List<int>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching exam ids in open session: {ex.Message}");
            return new List<int>();
        }
    }

    public async Task<List<StudentSubjectExamMarksDto>> GetStudentSingleSubjectExamMarksAsync(
    int sectionId, int schoolId, int subjectId, CancellationToken ct = default)
    {
        try
        {
            var url = $"api/ExamMarks/section/{sectionId}/school/{schoolId}/subject/{subjectId}/student-exam-marks";
            return await _http.GetFromJsonAsync<List<StudentSubjectExamMarksDto>>(url, ct) ?? new List<StudentSubjectExamMarksDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching single subject exam marks: {ex.Message}");
            return new List<StudentSubjectExamMarksDto>();
        }
    }

    public async Task<List<StudentSubjectExamMarksDto>> GetStudentSubjectExamMarksAsync(int sectionId, int schoolId, CancellationToken ct = default)
    {
        try
        {
            var url = $"api/ExamMarks/section/{sectionId}/school/{schoolId}/student-subject-exam-marks";
            return await _http.GetFromJsonAsync<List<StudentSubjectExamMarksDto>>(url, ct) ?? new List<StudentSubjectExamMarksDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching student subject exam marks: {ex.Message}");
            return new List<StudentSubjectExamMarksDto>();
        }
    }

    public async Task UpdateExamMarksAsync(List<ExamMarkUpdateDto> updates, CancellationToken ct = default)
    {
        try
        {
            var url = "api/ExamMarks/update-marks";
            var response = await _http.PostAsJsonAsync(url, updates, ct);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating exam marks: {ex.Message}");
            throw;
        }
    }

    public async Task<int> GetOpenExamIdAsync(int schoolId, CancellationToken ct = default)
    {
        try
        {
            var url = $"api/ExamMarks/school/{schoolId}/open-exam-id";
            return await _http.GetFromJsonAsync<int>(url, ct);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching open exam id: {ex.Message}");
            return 0;
        }
    }

    public async Task<List<StudentSubjectExamMarksDto>> GetStudentSubjectExamMarksExamOpenAsync(
        int sectionId, int schoolId, int subjectId, CancellationToken ct = default)
    {
        try
        {
            var url = $"api/ExamMarks/section/{sectionId}/school/{schoolId}/subject/{subjectId}/open-exam-marks";
            return await _http.GetFromJsonAsync<List<StudentSubjectExamMarksDto>>(url, ct) ?? new List<StudentSubjectExamMarksDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching open exam marks: {ex.Message}");
            return new List<StudentSubjectExamMarksDto>();
        }
    }
}


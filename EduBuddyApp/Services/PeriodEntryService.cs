using EduBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EduBuddyApp.Models;


namespace EduBuddyApp.Services
{
    public class PeriodEntryService : IPeriodEntryService
    {
        private readonly HttpClient _http;

        public PeriodEntryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PeriodAttendanceViewModel>> GetPeriodAttendanceAsync(int periodEntryId)
        {
            try
            {
                var url = $"api/PeriodAttendance/{periodEntryId}";
                var result = await _http.GetFromJsonAsync<List<PeriodAttendanceViewModel>>(url);
                return result ?? new List<PeriodAttendanceViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching period attendance: {ex.Message}");
                return new List<PeriodAttendanceViewModel>();
            }
        }

        public async Task<StudentPeriodAttendanceViewModel?> GetStudentPeriodAttendanceAsync(int studentId)
        {
            try
            {
                var url = $"api/PeriodAttendance/student/{studentId}";
                return await _http.GetFromJsonAsync<StudentPeriodAttendanceViewModel>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching student period attendance: {ex.Message}");
                return null;
            }
        }

        public async Task<StudentSubjectAttendanceSummaryViewModel?> GetStudentSubjectAttendanceSummaryAsync(int studentId)
        {
            try
            {
                var url = $"api/PeriodAttendance/student-subject-summary/{studentId}";
                return await _http.GetFromJsonAsync<StudentSubjectAttendanceSummaryViewModel>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching student subject attendance summary: {ex.Message}");
                return null;
            }
        }

        public async Task<AttendanceRowViewModel?> GetAttendanceRowAsync(int studentId)
        {
            try
            {
                var url = $"api/PeriodAttendance/attendance-row/{studentId}";
                return await _http.GetFromJsonAsync<AttendanceRowViewModel>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching attendance row: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdatePeriodAttendanceAsync(PeriodAttendanceUpdateDto dto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/PeriodAttendance/update", dto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating period attendance: {ex.Message}");
                return false;
            }
        }
    }
}
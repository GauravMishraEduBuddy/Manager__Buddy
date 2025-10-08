using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly HttpClient _http;

        public StudentAttendanceService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AttendanceDayViewModel> GetAttendanceDayAsync(int schoolId)
        {
            try
            {
                var url = $"api/StudentAttendance/attendanceday/{schoolId}";
                return await _http.GetFromJsonAsync<AttendanceDayViewModel>(url)
                    ?? new AttendanceDayViewModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching attendance day: {ex.Message}");
                return new AttendanceDayViewModel();
            }
        }

        public async Task<List<AttendanceViewModel>> GetAttendanceForSectionAsync(int sectionId, int attendanceDayId)
        {
            try
            {
                var url = $"api/StudentAttendance/section/{sectionId}/day/{attendanceDayId}";
                return await _http.GetFromJsonAsync<List<AttendanceViewModel>>(url)
                    ?? new List<AttendanceViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching attendance for section: {ex.Message}");
                return new List<AttendanceViewModel>();
            }
        }

        public async Task<bool> UpdateAttendancesAsync(int sectionId, int attendanceDayId, List<AttendanceViewModel> attendances)
        {
            try
            {
                var url = $"api/StudentAttendance/section/{sectionId}/day/{attendanceDayId}";
                var response = await _http.PutAsJsonAsync(url, attendances);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating attendances for section: {ex.Message}");
                return false;
            }
        }
    }
}
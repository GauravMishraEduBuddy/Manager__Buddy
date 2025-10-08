using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EduBuddyApp.Models;

namespace EduBuddyApp.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly HttpClient _http;

        public SubjectService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PeriodEntryViewModel>> GetPeriodEntryViewModelsAsync(int subjectId)
        {
            try
            {
                var url = $"api/Subject/{subjectId}/period-entry-viewmodels";
                var result = await _http.GetFromJsonAsync<List<PeriodEntryViewModel>>(url);
                return result ?? new List<PeriodEntryViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching period entry viewmodels: {ex.Message}");
                return new List<PeriodEntryViewModel>();
            }
        }

        public async Task<string> CreatePeriodEntryAsync(PeriodEntryCreateDto model)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Subject/period-entry", model);
                if (response.IsSuccessStatusCode)
                {
                    return "Period entry created successfully.";
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return $"Error {response.StatusCode}: {errorMessage}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception occurred: {ex.Message}";
            }
        }

        /// <summary>
        /// Updates a period entry using the backend API.
        /// </summary>
        /// <param name="periodEntryId">The ID of the period entry to update.</param>
        /// <param name="model">The updated period entry model.</param>
        /// <returns>A string message returned by the API, or an error message.</returns>
        public async Task<string> UpdatePeriodEntryAsync(int periodEntryId, PeriodEntryViewModel model)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Subject/period-entry/{periodEntryId}", model);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return !string.IsNullOrEmpty(result) ? result : "Period entry updated successfully.";
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return $"Error {response.StatusCode}: {errorMessage}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception occurred: {ex.Message}";
            }
        }

        /// <summary>
        /// Fetches subject details using the backend API.
        /// </summary>
        /// <param name="subjectId">The ID of the subject to fetch.</param>
        /// <returns>A SubjectDetailsViewModel object, or null if an error occurs.</returns>
        public async Task<SubjectDetailsViewModel?> GetSubjectAsync(int subjectId)
        {
            try
            {
                var url = $"api/Subject/{subjectId}";
                return await _http.GetFromJsonAsync<SubjectDetailsViewModel>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching subject details: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Checks if a subject period exists using the backend API.
        /// </summary>
        /// <param name="subjectId">The ID of the subject.</param>
        /// <param name="lectureDate">The date of the lecture.</param>
        /// <param name="lecturePeriod">The period of the lecture.</param>
        /// <param name="lectureSlot">The slot of the lecture.</param>
        /// <returns>True if the subject period exists, otherwise false.</returns>
        public async Task<bool> CheckSubjectPeriodExistsAsync(int subjectId, DateTime lectureDate, int lecturePeriod, int lectureSlot)
        {
            try
            {
                var url = $"api/Subject/check-subject-period?subjectId={subjectId}&lectureDate={lectureDate:yyyy-MM-dd}&lecturePeriod={lecturePeriod}&lectureSlot={lectureSlot}";
                var result = await _http.GetFromJsonAsync<bool>(url);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking subject period: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Checks if an employee period exists using the backend API.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <param name="lectureDate">The date of the lecture.</param>
        /// <param name="lecturePeriod">The period of the lecture.</param>
        /// <returns>True if the employee period exists, otherwise false.</returns>
        public async Task<bool> CheckEmployeePeriodExistsAsync(int employeeId, DateTime lectureDate, int lecturePeriod)
        {
            try
            {
                var url = $"api/Subject/check-employee-period?employeeId={employeeId}&lectureDate={lectureDate:yyyy-MM-dd}&lecturePeriod={lecturePeriod}";
                var result = await _http.GetFromJsonAsync<bool>(url);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking employee period: {ex.Message}");
                return false;
            }
        }

        public async Task<int> FindNextAvailableSlotAsync(int subjectId, DateTime lectureDate, int lecturePeriod)
        {
            try
            {
                var url = $"api/Subject/find-next-slot?subjectId={subjectId}&lectureDate={lectureDate:yyyy-MM-dd}&lecturePeriod={lecturePeriod}";
                var result = await _http.GetFromJsonAsync<int>(url);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding next available slot: {ex.Message}");
                return 0;
            }
        }
    }
}
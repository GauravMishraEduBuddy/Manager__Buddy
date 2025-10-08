using EduBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public class SchoolCalendarEventService : ISchoolCalendarEventService
    {
        private readonly HttpClient _http;

        public SchoolCalendarEventService(HttpClient http)
        {
            _http = http;
        }

        /// <summary>
        /// Gets all calendar events for a specific school
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <returns>A list of school calendar events</returns>
        public async Task<List<SchoolCalendarEvent>> GetSchoolCalendarEventsAsync(int schoolId)
        {
            try
            {
                var url = $"api/SchoolCalendarEvent/{schoolId}";
                var events = await _http.GetFromJsonAsync<List<SchoolCalendarEvent>>(url);
                return events ?? new List<SchoolCalendarEvent>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching school calendar events: {ex.Message}");
                return new List<SchoolCalendarEvent>();
            }
        }

        /// <summary>
        /// Gets all holidays for a specific school
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <returns>A list of school holidays as calendar events</returns>
        public async Task<List<SchoolCalendarEvent>> GetSchoolHolidaysAsync(int schoolId)
        {
            try
            {
                var url = $"api/SchoolCalendarEvent/holidays/{schoolId}";
                var holidays = await _http.GetFromJsonAsync<List<SchoolCalendarEvent>>(url);
                return holidays ?? new List<SchoolCalendarEvent>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching school holidays: {ex.Message}");
                return new List<SchoolCalendarEvent>();
            }
        }
    }
}
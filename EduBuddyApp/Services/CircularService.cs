using EduBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public class CircularService : ICircularService
    {
        private readonly HttpClient _http;

        public CircularService(HttpClient http)
        {
            _http = http;
        }

        /// <summary>
        /// Gets circulars for a specific school with optional audience scope filtering
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <param name="audienceScope">The audience scope to filter circulars (default: All)</param>
        /// <returns>A list of circulars</returns>
        public async Task<List<Circular>> GetCircularsAsync(int schoolId, AudienceScope audienceScope = AudienceScope.All)
        {
            try
            {
                var url = $"api/Circular/{schoolId}?audienceScope={audienceScope}";
                var circulars = await _http.GetFromJsonAsync<List<Circular>>(url);
                return circulars ?? new List<Circular>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching circulars: {ex.Message}");
                return new List<Circular>();
            }
        }
    }
}
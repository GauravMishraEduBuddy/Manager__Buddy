using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly CustomAuthStateProvider _state;

        public AuthService(HttpClient http,
                           AuthenticationStateProvider provider)
        {
            _http = http;
            _state = (CustomAuthStateProvider)provider;
        }

        public async Task<LoginResult> LoginAsync(string userName, string password)
        {
            var resp = await _http.PostAsJsonAsync("api/auth/login",
                new { userName, password });

            if (!resp.IsSuccessStatusCode)
                return new(false, 0, null, null);

            // DTO that matches the API response
            var payload = await resp.Content.ReadFromJsonAsync<LoginResponse>();
            if (payload is null)
                return new(false, 0, null, null);

            var jwt = payload.Token;
            var id = payload.EmployeeId;
            var schoolId = payload.SchoolId;

            // Persist token + employeeId
            await SecureStorage.SetAsync("jwt", jwt);
            await SecureStorage.SetAsync("employeeId", id.ToString());
            await SecureStorage.SetAsync("schoolId", schoolId?.ToString() ?? "");
            //IsCollege
            bool isCollege = schoolId.HasValue && schoolId.Value == 0; // Assuming 0 is the ID for college


            // Attach token to every outgoing request
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwt);

            // Update Blazor auth state (parses claims)
            _state.MarkUserAsAuthenticated(jwt);

            return new(true, id, schoolId, jwt);
        }

        public async Task LogoutAsync()
        {
            try
            {
                // delete the items instead of setting them to ""
                SecureStorage.Remove("jwt");
                SecureStorage.Remove("employeeId");
                SecureStorage.Remove("schoolId");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during secure storage operations
                Console.WriteLine($"Error during logout: {ex.Message}");
            }

            _state.MarkUserAsLoggedOut();
            _http.DefaultRequestHeaders.Authorization = null;
        }

        private record LoginResponse(string Token, int EmployeeId, int? SchoolId);
    }
}

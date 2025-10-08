using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly HttpClient _http;
        private readonly UserState _userState;

        public OpenAIService(HttpClient http, UserState userState)
        {
            _http = http;
            _userState = userState;
        }

        public async Task<string?> SendUserPromptAsync(string prompt, string? deployment = "gpt-5-mini")
        {
            var request = new OpenAIRequest
            {
                Prompt = prompt,
                Deployment = deployment,
                EmployeeId = _userState.EmployeeId
            };

            var response = await _http.PostAsJsonAsync("api/openai/user-prompt", request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Optionally handle error response
                return null;
            }
        }
    }

    public class OpenAIRequest
    {
        public string Prompt { get; set; } = string.Empty;
        public string? Deployment { get; set; }
        public int? EmployeeId { get; set; } // <-- Added property
    }
}
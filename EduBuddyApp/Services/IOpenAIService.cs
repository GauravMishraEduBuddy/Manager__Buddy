using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public interface IOpenAIService
    {
        Task<string?> SendUserPromptAsync(string prompt, string? deployment = "gpt-5-mini");
    }
}
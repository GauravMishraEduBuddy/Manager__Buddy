using EduBuddyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public interface ICircularService
    {
        /// <summary>
        /// Gets circulars for a specific school with optional audience scope filtering
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <param name="audienceScope">The audience scope to filter circulars (default: All)</param>
        /// <returns>A list of circulars</returns>
        Task<List<Circular>> GetCircularsAsync(int schoolId, AudienceScope audienceScope = AudienceScope.All);
    }
}
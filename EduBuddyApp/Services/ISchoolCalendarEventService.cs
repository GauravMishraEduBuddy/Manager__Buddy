using EduBuddyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public interface ISchoolCalendarEventService
    {
        /// <summary>
        /// Gets all calendar events for a specific school
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <returns>A list of school calendar events</returns>
        Task<List<SchoolCalendarEvent>> GetSchoolCalendarEventsAsync(int schoolId);

        /// <summary>
        /// Gets all holidays for a specific school
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <returns>A list of school holidays as calendar events</returns>
        Task<List<SchoolCalendarEvent>> GetSchoolHolidaysAsync(int schoolId);
    }
}
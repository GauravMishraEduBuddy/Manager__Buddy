using EduBuddyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public interface IStudentAttendanceService
    {
        Task<AttendanceDayViewModel> GetAttendanceDayAsync(int schoolId);
        
        // New method to get attendance data for a specific section and attendance day
        Task<List<AttendanceViewModel>> GetAttendanceForSectionAsync(int sectionId, int attendanceDayId);
        
        // Update attendance data for a specific section and attendance day
        Task<bool> UpdateAttendancesAsync(int sectionId, int attendanceDayId, List<AttendanceViewModel> attendances);
    }
}
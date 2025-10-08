using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public interface ITimetableService
{
    Task<List<TimetableDayViewModel>> GetTimetableDaysAsync(int employeeId);
}
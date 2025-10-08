using EduBuddyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static EduBuddyApp.Models.AttendanceRowViewModel;

namespace EduBuddyApp.Services
{
    public interface IPeriodEntryService
    {
        Task<List<PeriodAttendanceViewModel>> GetPeriodAttendanceAsync(int periodEntryId);
        Task<StudentPeriodAttendanceViewModel?> GetStudentPeriodAttendanceAsync(int studentId);
        Task<StudentSubjectAttendanceSummaryViewModel?> GetStudentSubjectAttendanceSummaryAsync(int studentId);

       
        Task<AttendanceRowViewModel?> GetAttendanceRowAsync(int studentId);
        //Post
        Task<bool> UpdatePeriodAttendanceAsync(PeriodAttendanceUpdateDto dto);
    }
}
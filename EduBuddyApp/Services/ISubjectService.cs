using EduBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public interface ISubjectService
    {
        Task<List<PeriodEntryViewModel>> GetPeriodEntryViewModelsAsync(int subjectId);
        Task<string> CreatePeriodEntryAsync(PeriodEntryCreateDto model);
        Task<string> UpdatePeriodEntryAsync(int periodEntryId, PeriodEntryViewModel model);
        Task<SubjectDetailsViewModel?> GetSubjectAsync(int subjectId);
        Task<bool> CheckSubjectPeriodExistsAsync(int subjectId, DateTime lectureDate, int lecturePeriod, int lectureSlot);
        Task<bool> CheckEmployeePeriodExistsAsync(int employeeId, DateTime lectureDate, int lecturePeriod);
        Task<int> FindNextAvailableSlotAsync(int subjectId, DateTime lectureDate, int lecturePeriod);

    }
}
using EduBuddyApp.Models;
using System.Threading.Tasks;

namespace EduBuddyApp.Services;

public interface ISyllabusService
{
    Task<List<SyllabusItem>> GetSubjectSyllabusAsync(int subjectId);
    Task<ChaptersViewModel?> GetChapterAsync(int chapterId);

    // New method to fetch period types for a given school ID.
    Task<List<PeriodTypeViewModel>> GetPeriodTypesAsync(int schoolId);

    Task<List<ChaptersViewModel>> GetChaptersForSubjectAsync(int subjectId);
}
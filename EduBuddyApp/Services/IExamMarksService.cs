using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public interface IExamMarksService
{
    Task<List<StudentClassMarkDto>> GetSectionExamMarksAsync(int sectionId, int examId, CancellationToken ct = default);
    Task<List<ExamsViewModel>> GetExamsInOpenSessionAsync(int schoolId, CancellationToken ct = default);
    Task<List<int>> GetExamIdsInOpenSessionAsync(int schoolId, CancellationToken ct = default);
    //Task<List<StudentSubjectExamMarksDto>> GetStudentSubjectExamMarksAsync(int sectionId, int schoolId, CancellationToken ct = default);
    Task<List<StudentSubjectExamMarksDto>> GetStudentSingleSubjectExamMarksAsync(
    int sectionId, int schoolId, int subjectId, CancellationToken ct = default);
    Task UpdateExamMarksAsync(List<ExamMarkUpdateDto> updates, CancellationToken ct = default);

    Task<int> GetOpenExamIdAsync(int schoolId, CancellationToken ct = default);
    Task<List<StudentSubjectExamMarksDto>> GetStudentSubjectExamMarksExamOpenAsync(
        int sectionId, int schoolId, int subjectId, CancellationToken ct = default);
}


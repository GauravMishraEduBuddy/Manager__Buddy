using EduBuddyApp.Models;

namespace EduBuddyApp.Services;

public interface ISectionService
{
    Task<SectionViewModel?> GetSectionAsync(int sectionId);
    Task<SectionViewModelDetailed?> GetSectionDatasetAsync(int sectionId);
    Task<List<StudentViewShortModel>?> GetStudentsInSectionAsync(int sectionId, CancellationToken ct = default);
}
using EduBuddyApp.Models;
namespace EduBuddyApp.Services;

public interface ISchoolService
{
    Task<List<School>> GetSchoolsAsync();
    Task<School?> GetSchoolAsync(int id);
    string GetSchoolLogoUrl(int id);

    Task<SchoolBasicViewModel?> GetBasicSchoolAsync(int schoolId);
}

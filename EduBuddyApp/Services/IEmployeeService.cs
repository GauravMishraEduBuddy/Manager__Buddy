namespace EduBuddyApp.Services;

using EduBuddyApp.Models;

    public interface IEmployeeService
    {
        Task<Employee?> GetEmployeeAsync(int employeeId);
        string GetStaffPhotoUrl(int staffId, int schoolId);
        Task<EmployeeBasicAPIDetailsDto?> GetEmployeeBasicAsync(int employeeId);
    }

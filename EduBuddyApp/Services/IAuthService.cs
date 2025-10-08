using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduBuddyApp.Services
{
    /// <summary>
    /// Carries the outcome of a login attempt along with the assigned EmployeeId
    /// and SchoolId.
    /// </summary>
    //public record LoginResult(bool IsSuccess, int EmployeeId, int? SchoolId);
    public record LoginResult(bool IsSuccess,
                         int Id,          // EmployeeId  OR StudentId
                         int? SchoolId,
                         string? Token);

    public interface IAuthService
    {
        /// <summary>
        /// Attempt to log in. Returns a LoginResult containing success flag,
        /// employeeId and schoolId.
        /// </summary>
        Task<LoginResult> LoginAsync(string userName, string password);

        /// <summary>
        /// Log out current user.
        /// </summary>
        Task LogoutAsync();
    }
}


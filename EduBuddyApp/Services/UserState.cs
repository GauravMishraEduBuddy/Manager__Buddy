using EduBuddyApp.Models;
using System.Collections.Generic;

namespace EduBuddyApp.Services;

public class UserState
{
    public int? EmployeeId { get; set; }
    public int? SchoolId { get; set; }
    public string? Jwt { get; set; }
    public bool IsCollege { get; set; } = false;
    public EmployeeBasicAPIDetailsDto? EmployeeDetails { get; set; }
    public List<FacilityStatusDto> FacilityStatuses { get; set; } = new();
}

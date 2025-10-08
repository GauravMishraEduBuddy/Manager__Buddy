namespace EduBuddyApp.Models;

public class AttendanceStatus
{
    public int AttendanceStatusId { get; set; }
    public string AttendanceName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int SchoolId { get; set; }
}

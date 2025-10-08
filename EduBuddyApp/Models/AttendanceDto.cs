namespace EduBuddyApp.Models;

public class AttendanceDto
{
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public int AttendanceStatusId { get; set; }
    public AttendanceType AttendanceType { get; set; }
    public string? Remarks { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}

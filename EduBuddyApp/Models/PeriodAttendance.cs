using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBuddyApp.Models;

public class PeriodAttendanceViewModel
{
    public int PeriodAttendanceId { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int PeriodEntryId { get; set; }
    public string SubjectName { get; set; }
    public int LecturePeriod { get; set; }
    public bool IsPresent { get; set; }
}

public class StudentPeriodAttendanceViewModel
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public Dictionary<int, PeriodAttendanceInfo> PeriodAttendance { get; set; } // PeriodEntryId -> Attendance Info
}
public class PeriodAttendanceInfo
{
    public bool? IsPresent { get; set; }
    public DateTime LectureDate { get; set; }
    public int LecturePeriod { get; set; }
}
public class StudentSubjectAttendanceSummaryViewModel
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public Dictionary<int, SubjectAttendanceSummary> SubjectAttendance { get; set; } // SubjectId -> Attendance Summary
}

public class SubjectAttendanceSummary
{
    public int PresentCount { get; set; }    // Count of Present days
    public int TotalDaysCount { get; set; }  // Count of Total filled days
}

public class PeriodAttendanceUpdateDto
{
    public int StudentId { get; set; }
    public int PeriodEntryId { get; set; }
    public bool IsPresent { get; set; }
}

public class AttendanceRowViewModel
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string? FatherName { get; set; }
    public string? FatherMobileNo { get; set; }
    public Dictionary<DateTime, bool> AttendanceRecords { get; set; } = new Dictionary<DateTime, bool>();

    public string? SchoolClassName { get; set; }
    public string? SectionName { get; set; }
    public string? AdmissionReference { get; set; }
    public string FormattedAttendancePercentage
    {
        get
        {
            double percentage = CalculateAttendancePercentage();
            return $"{percentage:0}%";  // Ensure this calculates the percentage
        }
    }
    public double GetNumericPercentage()
    {
        return double.Parse(FormattedAttendancePercentage.TrimEnd('%'));
    }


    public double CalculateAttendancePercentage()
    {
        // Assume AttendanceRecords is a Dictionary<DateTime, bool>
        int presentDays = AttendanceRecords.Count(kvp => kvp.Value);
        int totalDays = AttendanceRecords.Count;
        return totalDays > 0 ? (100.0 * presentDays / totalDays) : 0.0;
    }
    // Method to calculate attendance percentage
    public double CalculateAttendancePercentageold()
    {
        if (AttendanceRecords.Count == 0) return 0.0;
        int presentCount = AttendanceRecords.Count(record => record.Value);
        return (double)presentCount / AttendanceRecords.Count * 100;
    }

    


}
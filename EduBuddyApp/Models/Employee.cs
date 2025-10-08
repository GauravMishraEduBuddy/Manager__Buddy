using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBuddyApp.Models;

public class Designation
{
    public int DesignationId { get; set; }
    [Required]
    [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
    public string DesignationName { get; set; }
    public bool IsTeaching { get; set; }
    public bool IsSupportStaff { get; set; }
    public int SchoolId { get; set; }
    public virtual School School { get; set; }

}
public class Employee
{
    public int EmployeeID { get; set; }
    [Required]
    [StringLength(255, ErrorMessage = "The name must be less than 255 characters.")]
    public string EmployeeName { get; set; }
    //ExternalEmployeeId
    [StringLength(50, ErrorMessage = "The name must be less than 50 characters.")]
    public string? ExternalEmployeeID { get; set; } //old ID from previous system
    public int DesignationId { get; set; }
    public Boolean Working { get; set; }
    [StringLength(255, ErrorMessage = "Employee Role name must be less than 255 characters.")]
    public string? EmployeeRole { get; set; }
    public bool IsInDailyAttendance { get; set; }


    [DataType(DataType.EmailAddress)]
    [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
    public string? EmployeeEmail { get; set; }

    [DataType(DataType.EmailAddress)]
    [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
    public string? EmployeeOfficialEmail { get; set; }
    [Display(Name = "Mobile Number:")]

    [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
    public string? EmployeeMobile1 { get; set; }
    [Display(Name = "2ndMobile Number:")]
    [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
    public string? EmployeeMobile2 { get; set; }


    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? EmployeeDOB { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? EmployeeDOJ { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? EmployeeDOL { get; set; }

    public Gender? Gender { get; set; }
    public int SchoolID { get; set; }
    //cusomterization properties
    public bool? HaveDarkTheme { get; set; }

    public bool IsInSalary { get; set; }
    public decimal? BasicSalary { get; set; }
    public string? SalaryComments { get; set; }

    //new properties
    [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
    public string? ESICNumber { get; set; }

    [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
    public string? EPFONumber { get; set; }

    [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
    public string? AadharNumber { get; set; }
    [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
    public string? PanNumber { get; set; }
    [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
    public string? DrivingLicense { get; set; }

    // Navigation properties
    public virtual ICollection<TeacherSubjectSection> TeacherSubjectSections { get; set; }
    public virtual Designation Designation { get; set; }
    public virtual School School { get; set; }
    //public ICollection<SchoolVisitEmployee> SchoolVisitEmployees { get; set; } // Navigation property
                                                                               // Navigation property back to ApplicationUser
    //public ApplicationUser ApplicationUser { get; set; }

    // all student-records that refer to this employee as “parent”
    public virtual ICollection<StudentRecords> StudentRecordsAsChild { get; set; }
        = new List<StudentRecords>();
}

//attendance
public class EmployeeAttendance
{
    public int EmployeeAttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public int AttendanceStatusId { get; set; }
    public string? Remarks { get; set; }

    // New GPS properties
    [Column(TypeName = "decimal(9,6)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(9,6)")]
    public decimal? Longitude { get; set; }

    public AttendanceType AttendanceType { get; set; }

    public virtual AttendanceStatus AttendanceStatus { get; set; }
    public virtual Employee Employee { get; set; }
}



public class EmployeeAttendanceViewModel
{
    public int EmployeeAttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string? DesignationName { get; set; }
    public string? EmployeeRole { get; set; }
    public DateTime AttendanceDate { get; set; }
    public int AttendanceStatusId { get; set; }
    public string AttendanceName { get; set; }
    public string? Remarks { get; set; }
    public AttendanceType AttendanceType { get; set; } // In, Out, Other
}






//Viewmodels

public class EmployeeViewModel
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public Gender? Gender { get; set; }
    //ExternalEmployeeID
    public string? ExternalEmployeeID { get; set; }
    public int? SchoolId { get; set; }
    public string? SchoolName { get; set; }
    public Boolean Working { get; set; }
    public string? EmployeeRole { get; set; }
    public bool IsInDailyAttendance { get; set; }
    public string? EmployeeEmail { get; set; }
    public string? EmployeeOfficialEmail { get; set; }
    public string? EmployeeMobile1 { get; set; }
    public string? EmployeeMobile2 { get; set; }
    public DateTime? EmployeeDOB { get; set; }
    public DateTime? EmployeeDOJ { get; set; }
    // URL to staff photo stored in blob container
    public string? EmployeeImageUrl { get; set; }
    public string? AadharNumber { get; set; }
    public string? PanNumber { get; set; }
    public string? DrivingLicense { get; set; }
    public string? ESICNumber { get; set; }
    public string? EPFONumber { get; set; }

    public string? DesignationName { get; set; }
    //IsInDailyAttendance


    public DateTime? EmployeeDOL { get; set; }
    public bool IsSupportStaff { get; set; }
    //BasicSalary
    public decimal? BasicSalary { get; set; }
    public string? SalaryComments { get; set; }

    // Used only for editing opening balances. Stored separately in
    // OpeningBalance table.
    public decimal OpeningBalance { get; set; }

    // List of Subjects taught by the Employee
    public List<SubjectViewModelList> Subjects { get; set; } = new List<SubjectViewModelList>();
}

public class EmployeeAttendanceDay
{
    public DateTime AttendanceDate { get; set; }
    public List<EmployeeAttendanceViewModel> EmployeeAttendances { get; set; } = new();
}

public class DynamicAttendanceRow
{
    public int EmployeeId { get; set; } // Static column
    public string EmployeeName { get; set; } // Static column
    public Dictionary<DateTime, string> AttendanceData { get; set; } = new Dictionary<DateTime, string>();
}




public class EmployeeBasicAPIDetailsDto
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public Gender? Gender { get; set; }
    public string DesignationName { get; set; } = string.Empty;
    public bool IsTeaching { get; set; }
    public bool IsInDailyAttendance { get; set; }
    public string? EmployeeEmail { get; set; }
    public string? EmployeeMobile1 { get; set; }
    public int? ClassTeacherSchoolClassId { get; set; }

    public ICollection<TeacherSubjectDto> TeacherSubjects { get; set; } = new List<TeacherSubjectDto>();
}

public class TeacherSubjectDto
{
    public int SubjectID { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int SectionId { get; set; }
    public int? SchoolClassId { get; set; }
    public string SectionName { get; set; } = string.Empty;
    public string SchoolClassName { get; set; } = string.Empty;
    public Byte? WeeklyLoad { get; set; }
    public ReportCardStatus? ReportCardStatus { get; set; }
    public int? ReportCardOrder { get; set; }


    //public string? ChapterActivity { get; set; } // Optional field for chapter or activity name

    public string ClassAndSectionName
    {
        get
        {
            if (!string.IsNullOrEmpty(SchoolClassName))
            {
                return $"{SchoolClassName}-{SectionName}";
            }
            return SectionName;
        }
    }

    //a calulated property to return ClassAndSectionName-SubjectName
    public string ClassSectionAndSubjectName
    {
        get
        {
            if (!string.IsNullOrEmpty(SchoolClassName))
            {
                return $"{SchoolClassName}-{SectionName} - {SubjectName}";
            }
            return $"{SectionName} - {SubjectName}";
        }
    }
}




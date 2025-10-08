using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBuddyApp.Models;

    public class Exam
    {
        public int ExamId { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string ExamName { get; set; }
        public bool IsExamOpen { get; set; }
        public string? Comments { get; set; }
        public int AcademicSessionId { get; set; }
        public int ExamTypeId { get; set; }
        public int SchoolId { get; set; }
        public Int16? MarksWeightage { get; set; }
        public bool IsPosted { get; set; }

        // New property to link the exam to a report card template in Blob Storage
        public int? ReportCardBlobItemId { get; set; } // Nullable if not all exams need a report card template

        // Navigation properties
        public virtual BlobItemTable? ReportCardBlobItem { get; set; } // Reference to BlobItemTable

        public virtual AcademicSession AcademicSession { get; set; }

        public virtual ExamType ExamType { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<ExamMarks> ExamMarks { get; set; }
        public virtual ICollection<ExamStudentObservation> ExamStudentObservations { get; set; }
        public virtual ICollection<ChapterExamLink> ChapterExamLinks { get; set; }
    }

    public class ExamType
    {
        public int ExamTypeId { get; set; }
        [Required(ErrorMessage = "Exam Type is required.")]
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string ExamTypeName { get; set; }
        public int SchoolId { get; set; }

        // Navigation properties
        public virtual School School { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
    public class ExamMarks
    {
        public int ExamMarksId { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        // public decimal Marks { get; set; } // Consider using a numeric type for marks
        public decimal? NumericMarks { get; set; } // Nullable for when grades are used instead
        [StringLength(5)]
        public string? LetterGrade { get; set; } // For when letter grades are applicable
        public decimal MaxMarks { get; set; }  // Maximum marks for the subject
        public string? TeacherComments { get; set; }  // Teacher's comments for the subject


        // Navigation properties
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
    public class ExamSectionObservation
    {
        public int ExamSectionObservationId { get; set; }
        public int ExamId { get; set; }
        public int SectionId { get; set; } // Link to a specific section

        // Observation titles for the section
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation1Title { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation2Title { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation3Title { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation4Title { get; set; }

        // Reference to the ReportCard stored in Blob Storage
        public string? ReportCardBlobUri { get; set; } // URI of the report card file in the blob container

        // Navigation properties
        public virtual Exam Exam { get; set; }
        public virtual Section Section { get; set; }
        // Computed property for displaying Class-Section name
        [NotMapped]
        public string ClassSectionName => $"{Section?.SchoolClass?.ClassName} - {Section?.SectionName}";

    }



    public class ExamStudentObservation
    {
        public int ExamStudentObservationId { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        //public string? Observations { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation1Title { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation2Title { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation3Title { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? Observation4Title { get; set; }

        [StringLength(555, ErrorMessage = "Must be less than 555 characters.")]
        public string? Observation1 { get; set; }
        [StringLength(555, ErrorMessage = "Must be less than 555 characters.")]
        public string? Observation2 { get; set; }
        [StringLength(555, ErrorMessage = "Must be less than 555 characters.")]
        public string? Observation3 { get; set; }
        [StringLength(555, ErrorMessage = "Must be less than 555 characters.")]
        public string? Observation4 { get; set; }
        [StringLength(555, ErrorMessage = "Must be less than 555 characters.")]
        public string? TeacherRemarks { get; set; }  // Class Teacher Remarks
        public string? StudentPerformance { get; set; }  // Student's performance summary
        public string? StudentPerformanceFeedback { get; set; }  // Student's performance feedback
        //new properties
        //int Presentdays, int TotalDays, int ClassRank, string? Grade, string? FinalResult
        public int PresentDays { get; set; }
        public int TotalDays { get; set; }
        public int ClassRank { get; set; }
        [StringLength(25, ErrorMessage = "Must be less than 25 characters.")]
        public string? Grade { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? FinalResult { get; set; }

        public decimal? TotalMarks { get; set; }
        public decimal? TotalMaxMarks { get; set; }
       


        // Navigation properties
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
    }

    public class ExamStudentObservationViewModel
    {
        public int ExamStudentObservationId { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public string? StudentName { get; set; }  // Add this for display purposes
        public int SectionId { get; set; }

        public string? Observation1 { get; set; }

        public string? Observation2 { get; set; }

        public string? Observation3 { get; set; }

        
        public string? Observation4 { get; set; }

     
        public string? TeacherRemarks { get; set; }
        public string? StudentExamPerformance { get; set; } // New property
        public string? StudentPerformanceFeedback { get; set; } // New property
        public int PresentDays { get; set; }
        public int TotalDays { get; set; }
        public int ClassRank { get; set; }
        [StringLength(25, ErrorMessage = "Must be less than 25 characters.")]
        public string? Grade { get; set; }
        [StringLength(255, ErrorMessage = "Must be less than 255 characters.")]
        public string? FinalResult { get; set; }
        public decimal? TotalMarks { get; set; }
        public decimal? TotalMaxMarks { get; set; }
    }

    public class StudentExamMarksViewModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public decimal? TotalMarks { get; set; }
        public string? SectionName { get; set; }
        public string? ClassName { get; set; }
        

        // Include other student properties as needed
        //public Dictionary<int, decimal>? MarksBySubject { get; set; } // SubjectId, Marks
        public Dictionary<int, MarkOrGrade>? MarksBySubject { get; set; } // SubjectId, MarkOrGrade
                                                                          // New properties for highest and average marks
        public Dictionary<int, decimal?> HighestMarksBySubject { get; set; } = new Dictionary<int, decimal?>();
        public Dictionary<int, decimal?> AverageMarksBySubject { get; set; } = new Dictionary<int, decimal?>();
        //set for MaxMarks 
        public Dictionary<int, decimal?> MaxMarksBySubject { get; set; } = new Dictionary<int, decimal?>();
        // New property for the performance summary string
        public string? StudentExamPerformance { get; set; } // New property
        public string? StudentPerformanceFeedback { get; set; } // New property
        //include Observation1Title-Observation4Title
        public string? Observation1Title { get; set; }
        public string? Observation2Title { get; set; }
        public string? Observation3Title { get; set; }
        public string? Observation4Title { get; set; }
        public string? Observation1 { get; set; }
        public string? Observation2 { get; set; }
        public string? Observation3 { get; set; }
        public string? Observation4 { get; set; }
        public string? TeacherRemarks { get; set; }
        //int Presentdays, int TotalDays, int ClassRank, string? Grade, string? FinalResult
        public int PresentDays { get; set; }
        public int TotalDays { get; set; }
        public int ClassRank { get; set; }
        public string? Grade { get; set; }
        public string? FinalResult { get; set; }

        public Dictionary<int, decimal> ExamTotals { get; set; } = new();

        // Nested structure: ExamId => (SubjectId => MarkOrGrade)
        public Dictionary<int, Dictionary<int, MarkOrGrade>> ExamSubjectMarks { get; set; } = new();



    }
    public class MarkOrGrade
    {
        public decimal? NumericMark { get; set; }
        public string LetterGrade { get; set; }
        public ReportCardStatus? Status { get; set; }
        public decimal? MaxMarks { get; set; }


    }

    public class ExamsViewModel
    {
        public int ExamId { get; set; }
        public int SchoolId { get; set; }
        public string? SchoolName { get; set; }
        public string ExamName { get; set; }
        public bool IsExamOpen { get; set; }
        public string? Comments { get; set; }
        public int AcademicSessionId { get; set; }
        public bool? IsAcademicSessionOpen { get; set; }
        public bool? IsPosted { get; set; }
        public bool? IsComposite { get; set; }
        public string? AcademicSessionName { get; set; }
        public int ExamTypeId { get; set; }
        public string? ExamTypeName { get; set; }
        public Int16? MarksWeightage { get; set; }
        public string? blobitemtableName { get; set; }
        public int? ReportCardBlobItemId { get; set; }

        [NotMapped] // Indicates this property should not be mapped to the database
        public int AutoIncrementNumber { get; set; }

    }
    public class MarksEntryViewModel
    {
        public int SubjectId { get; set; }
        public int SectionId { get; set; }
        public int ExamId { get; set; } // Assuming this is the IsOpenExamId
        public ReportCardStatus? ReportCardStatus { get; set; }
        public List<StudentExamMarksViewModel>? StudentExamMarks { get; set; }
        //public List<StudentMarkEntry> StudentsMarks { get; set; }

    }

    public class StudentReportCardViewModel
    {
        public StudentDocumentViewModel StudentInfo { get; set; }
        public StudentExamMarksViewModel ExamInfo { get; set; }

        public StudentReportCardViewModel()
        {
            StudentInfo = new StudentDocumentViewModel();
            ExamInfo = new StudentExamMarksViewModel();
        }
    }


    public class StudentExamDocumentViewModel
    {
        // Key Student Properties Included Directly
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? ClassName { get; set; }
        public int? SectionID { get; set; }
        public string? SectionName { get; set; }
        public string? HouseName { get; set; }
        public string? ClassTeacherName { get; set; }
        public string? StudentImageUrl { get; set; }

        // Reference to Full Student Details
        public StudentDocumentViewModel StudentDetails { get; set; }

        // Exam-Specific Properties
        public int ExamId { get; set; }
        public string? ExamName { get; set; }
        //MarksWeightage
        public Int16? MarksWeightage { get; set; }
        public decimal? TotalMarks { get; set; }
        public decimal? TotalMaxMarks { get; set; }
        public decimal? TotalMarksPercentage { get; set; }
        public decimal? TotalAverageMarks { get; set; }
        public decimal? TotalHighestMarks { get; set; }


        // Subject metadata
        public List<Subject>? StuSubjects { get; set; } = new List<Subject>();
        public Dictionary<int, MarkOrGrade>? MarksBySubject { get; set; } = new Dictionary<int, MarkOrGrade>();
        public Dictionary<int, decimal?> HighestMarksBySubject { get; set; } = new Dictionary<int, decimal?>();
        public Dictionary<int, decimal?> AverageMarksBySubject { get; set; } = new Dictionary<int, decimal?>();
        public Dictionary<int, decimal?> MaxMarksBySubject { get; set; } = new Dictionary<int, decimal?>();

        // Performance and Observations
        public string? StudentExamPerformance { get; set; }
        public string? StudentPerformanceFeedback { get; set; }
        public string? Observation1Title { get; set; }
        public string? Observation2Title { get; set; }
        public string? Observation3Title { get; set; }
        public string? Observation4Title { get; set; }
        public string? Observation1 { get; set; }
        public string? Observation2 { get; set; }
        public string? Observation3 { get; set; }
        public string? Observation4 { get; set; }
        public string? TeacherRemarks { get; set; }

        // Attendance and Final Evaluation
        public int PresentDays { get; set; }
        public int TotalDays { get; set; }
        public int PresentPercentage { get; set; }
        public int ClassRank { get; set; }
        public string? Grade { get; set; }
        public string? FinalResult { get; set; }

        // Additional Properties for Document Customization
        public string? Blank1 { get; set; }
        public string? Blank2 { get; set; }
        public string? Blank3 { get; set; }
    }

    public class StudentTotalMarksViewModel
    {
        public int StudentId { get; set; }
        public decimal TotalMarks { get; set; }
        public decimal TotalMaxMarks { get; set; }
    }

    // ViewModel for subject marks data
    public class SubjectMarksData
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public double Marks { get; set; }
        public double ClassAverage { get; set; }
        public double ClassHighest { get; set; }
        public double SubjectMaxMarks { get; set; }
    }

    public class SubjectExamMarksData
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string ExamName { get; set; }
        public double Marks { get; set; }
    }

    public enum ReportOutputAction
    {
        ShowPdfViewer,
        ShowWordViewer,
        DownloadPdf,
        DownloadWord
    }

    /// <summary>
    /// Represents aggregated analytics for a subject in an exam.
    /// </summary>
    public class SubjectAnalyticsResult
    {
        public string SubjectName { get; set; } = string.Empty;
        public decimal HighestMarks { get; set; }
        public decimal LowestMarks { get; set; }
        public decimal AverageMarks { get; set; }
    }
    public class GradeCount
    {
        public string SubjectName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public int Count { get; set; }
    }

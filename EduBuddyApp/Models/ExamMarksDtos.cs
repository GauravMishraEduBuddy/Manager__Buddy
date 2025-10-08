using System.Collections.Generic;

namespace EduBuddyApp.Models
{
    public class MarkOrGradeDto
    {
        public decimal? NumericMark { get; set; }
        public string? LetterGrade { get; set; }
    }

    public class StudentClassMarkDto
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal? TotalMarks { get; set; }
        public string? StudentExamPerformance { get; set; }
        public string? StudentPerformanceFeedback { get; set; }
        public string? TeacherRemarks { get; set; }
        public Dictionary<int, MarkOrGradeDto> MarksBySubject { get; set; } = new();
    }

    /// <summary>
    /// Represents a subject that can appear in the class marks table header.
    /// </summary>
    public class SubjectDto
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;
    }

    public class StudentSubjectExamMarksDto
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        // Key: ExamId, Value: Mark/Grade for this subject in that exam
        public List<ExamMarkEntryDto> MarksByExam { get; set; } = new();
        // Optionally, add performance/remarks if needed
        public string? StudentExamPerformance { get; set; }
        public string? StudentPerformanceFeedback { get; set; }
        public string? TeacherRemarks { get; set; }
    }
    public class ExamMarkEntryDto
    {
        public int ExamId { get; set; }
        public decimal? NumericMark { get; set; }
        public string? LetterGrade { get; set; }
    }

    //maybe not required
    public class SectionSubjectExamMarksDto
    {
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        // List of all exams for this subject in this section (can be provided separately)
        public List<int> ExamIds { get; set; } = new();
        // Or, if you want to include exam metadata:
        // public List<ExamsViewModel> Exams { get; set; } = new();
        public List<StudentSubjectExamMarksDto> StudentMarks { get; set; } = new();
    }

    public class ExamMarkUpdateDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ExamId { get; set; }
        public decimal? NumericMark { get; set; }
        public string? LetterGrade { get; set; }
        public decimal MaxMarks { get; set; } // <-- Added property
    }
}

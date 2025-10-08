using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBuddyApp.Models;

    public class DaySchedule
    {
        [Key]
        public int DayScheduleId { get; set; }

        [Required]
        public int SectionId { get; set; }

        [Required]
        [Range(1, 7, ErrorMessage = "Day of the week must be between 1 (Monday) and 7 (Sunday)")]
        public int DayOfWeek { get; set; }

        // Navigation property to Section
        public virtual Section Section { get; set; }

        // Collection of TimetablePeriods
        public virtual ICollection<TimetablePeriod> TimetablePeriods { get; set; }
    }
    public class TimetablePeriod
    {
        [Key]
        public int TimetablePeriodId { get; set; }
        [Required]
        public int DayScheduleId { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Period number must be between 1 and 10")]
        public int PeriodNumber { get; set; }
       
        public TimeSpan StartTime { get; set; }
       
        public TimeSpan EndTime { get; set; }

        // Navigation property to DaySchedule
        public virtual DaySchedule DaySchedule { get; set; }

        // Remove old navigation properties if they exist
        // public virtual Subject Subject { get; set; }

        // New navigation property for associated subjects via PeriodSubjects
        public virtual ICollection<PeriodSubject> PeriodSubjects { get; set; }
    }

  
    public class PeriodSubject
    {
        public int TimetablePeriodId { get; set; }
        public TimetablePeriod TimetablePeriod { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        // Include GroupId to keep track of the group during scheduling
        public int? GroupId { get; set; }
        public Group Group { get; set; }

    }
    public class PeriodEditViewModel
    {
        public int PeriodNumber { get; set; }
        public List<SelectItem> SubjectTeacherOptions { get; set; }
        public List<int> SelectedSubjectIds { get; set; } = new List<int>();
    }
   


    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }  // Example: "9-A CS & 9-Commerce CS"
        //public int SchoolId { get; set; }
       // public Branch? Branch { get; set; }

        //public virtual School School { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }

    public class TimetableDayViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public string Period1 { get; set; }
        public string Period2 { get; set; }
        public string Period3 { get; set; }
        public string Period4 { get; set; }
        public string Period5 { get; set; }
        public string Period6 { get; set; }
        public string Period7 { get; set; }
        public string Period8 { get; set; }
        public string Period9 { get; set; }
        public string Period10 { get; set; }
    }
    

    public class DayEditViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public List<PeriodEditViewModel> Periods { get; set; }
    }

    public class SelectItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public string? GroupName { get; set; } // New field to display group information
    }

    public class GroupModel
    {
        [Required(ErrorMessage = "Group name is required")]
        [StringLength(100, ErrorMessage = "Group name must be under 100 characters")]
        public string GroupName { get; set; }

       

        [Required(ErrorMessage = "You must select a subject")]
        public int? SubjectId { get; set; }
    }

    public class GroupModel2
    {
      
        [Required(ErrorMessage = "You must select a subject")]
        public int? SubjectId { get; set; }
    }

    
    public class TeacherScheduleViewModel
    {
        public int PeriodNumber { get; set; }
        public string PeriodDetails { get; set; }
        public MarkupString FreeTeachers { get; set; } // Now a MarkupString to include links
        //public string FreeTeachers { get; set; }
       // public List<string> FreeTeachers { get; set; } = new List<string>();
    }

    //below viewmodel is for passing record to OpenAI API with full Timetable details
    public class TimeTableDetailsViewModel
    {
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public int PeriodNumber { get; set; }
    }
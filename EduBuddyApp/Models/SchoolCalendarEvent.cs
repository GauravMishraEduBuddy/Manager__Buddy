using System.ComponentModel.DataAnnotations;

namespace EduBuddyApp.Models
{
    public class SchoolCalendarEvent
    {
        [Key] public int EventId { get; set; }

        [Required] public int SchoolId { get; set; }     // Tenant

        [Required] public CalendarEventType EventType { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = default!;

        public string? Location { get; set; }

        public string? Description { get; set; }

        [Required] public DateTime StartTime { get; set; }
        [Required] public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; } = true;

        public string? RecurrenceRule { get; set; }
        public string? RecurrenceException { get; set; }
        public int? RecurrenceId { get; set; }

        public string? CategoryColor { get; set; }

        [Required]                           // NEW
        public CalendarAudience Audience { get; set; } = CalendarAudience.ShowAll;

        public bool IsSchoolClosed { get; set; }         // Useful for holidays

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }

        //navigation to School entity
        public virtual School? School { get; set; }
    }

    public enum CalendarEventType: Byte
    {
        Event = 0,
        Holiday = 1,
        ExamBreak = 2,
        Other = 3
    }

    public enum CalendarAudience : Byte
    {
        ShowAll = 0,          // Everyone logged in can see it
        ShowOnlyStaff = 1,    // Teachers / admins / non-teaching staff
        ShowOnlyStudents = 2  // Students (and usually their parents)
                              // You can extend later: ShowOnlyParents = 3, CustomGroup = 4 …
    }


}

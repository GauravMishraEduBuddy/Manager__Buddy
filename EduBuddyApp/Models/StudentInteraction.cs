using System.ComponentModel.DataAnnotations;

namespace EduBuddyApp.Models
{
    /// <summary>
    /// Types of student–guardian interactions logged by teachers.
    /// </summary>
    public enum InteractionType: Byte
    {
        Call = 0,
        ParentConcern = 1,
        PTM = 2   // Parent–Teacher Meeting
    }

    /// <summary>
    /// Outcome status for each interaction.
    /// </summary>
    public enum ResolutionStatus : Byte
    {
        Open = 0,
        InProgress = 1,
        Resolved = 2,
        Escalated = 3
    }

    /// <summary>
    /// Records every interaction a teacher has logged for a student.
    /// </summary>
    public class StudentInteraction
    {
        [Key]
        public int StudentInteractionId { get; set; }

        [Required]
        public int SchoolId { get; set; }            // Tenant

        [Required]
        public int StudentId { get; set; }           // FK → Student

        [Required]
        public int EmployeeId { get; set; }          // FK → Teacher/Staff who logged

        [Required]
        public InteractionType InteractionType { get; set; }

        [Required]
        public DateTime InteractionDateTime { get; set; }

        [Required, MaxLength(1000)]
        public string Summary { get; set; } = default!;

        public DateTime? FollowUpDate { get; set; }

        [Required]
        public ResolutionStatus ResolutionStatus { get; set; } = ResolutionStatus.Open;

        // Auditing
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBuddyApp.Models
{
    /// <summary>
    /// Who should see a Circular in the portal.
    /// </summary>
    public enum AudienceScope: Byte
    {
        All = 0,  // Everyone: staff, students, parents
        StaffOnly = 1,  // Teachers and administrators
        ParentsOnly = 2,  // Students’ guardians (and you could expose to students implicitly)
        CustomGroup = 3   // See CircularCustomGroup map for specific roles/users
    }

    /// <summary>
    /// A school-wide announcement or circular, optionally targeted and scheduled.
    /// </summary>
    public class Circular
    {
        [Key]
        public int CircularId { get; set; }

        [Required]
        public int SchoolId { get; set; }                   // Tenant

        [Required]
        public AudienceScope AudienceScope { get; set; }    // Visibility

        [Required, MaxLength(200)]
        public string Title { get; set; } = default!;

        /// <summary>
        /// Main text of the circular; use HTML/Markdown as your UI permits.
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// If you need an attachment, store the blob name or URI here.
        /// </summary>
        [MaxLength(500)]
        public string? AttachmentBlobName { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }           // When it goes live

        public DateTime? ExpiryDate { get; set; }           // When it should auto-hide

        /// <summary>
        /// If true, trigger push/SMS/email notifications on PublishDate.
        /// </summary>
        public bool IsPushNotified { get; set; } = false;

        // Audit
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }

        // Navigation
        [ForeignKey(nameof(SchoolId))]
        public virtual School? School { get; set; }

        /// <summary>
        /// If AudienceScope == CustomGroup, use this join table to pick exact recipients.
        /// </summary>
        public virtual ICollection<CircularCustomGroup>? CustomGroups { get; set; }
    }

    /// <summary>
    /// Join table for custom audience segments (e.g. “Grade 5 parents”, “Bus-route A students”) 
    /// </summary>
    public class CircularCustomGroup
    {
        [Key]
        public int Id { get; set; }

        // Multitenancy
        [Required]
        public int SchoolId { get; set; }

        [Required]
        public int CircularId { get; set; }

        /// <summary>
        /// Human-readable label shown in the UI.
        /// </summary>
        [Required, MaxLength(100)]
        public string Label { get; set; } = default!;

        // Navigation
        [ForeignKey(nameof(CircularId))]
        public virtual Circular Circular { get; set; } = default!;
    }

}

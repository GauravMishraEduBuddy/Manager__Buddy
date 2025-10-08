using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBuddyApp.Models
{
    public class EduBuddyFacility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EduBuddyFacilityId { get; set; }

        [Required]
        [StringLength(200)]
        public string FacilityName { get; set; } = null!;

        public string? Description { get; set; }

        public virtual ICollection<EduBuddySubscription>? EduBuddySubscriptions { get; set; }
    }

    public class EduBuddySubscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EduBuddySubscriptionId { get; set; }
        public int SchoolId { get; set; }
        public int EduBuddyFacilityId { get; set; }
        public bool IsAllowed { get; set; } = true;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual School School { get; set; } = null!;
        public virtual EduBuddyFacility EduBuddyFacility { get; set; } = null!;
    }

    public class FacilityStatusDto
    {
        public string FacilityName { get; set; }
        public bool IsEnabled { get; set; }
    }
}

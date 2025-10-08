using System;
using System.ComponentModel.DataAnnotations;

namespace EduBuddyApp.Models
{
    public class PeriodEntryCreateDto
    {
        public int? SubjectId { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public int PeriodTypeId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime LectureDate { get; set; }
        
        [Required]
        [Range(1, 9, ErrorMessage = "Value must be between 1 (first period) and 9 (last period)")]
        public int LecturePeriod { get; set; }
        
        [Range(1, 9, ErrorMessage = "Lecture slot must be between 1 and 9")]
        public int? LectureSlot { get; set; }
        
        [Required]
        [StringLength(1000, MinimumLength = 15, ErrorMessage = "Details must be between 15 and 1000 characters")]
        public string Details { get; set; }
        
        public int? ChapterId { get; set; }
        
        
    }
}
using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace EduBuddyApp.Models
{
    public class ChapterEditDto
    {
        public int? ChapterID { get; set; } // For update, required; for create, can be null
        [Required]
        public int BookID { get; set; }
        [Required]
        public int ChapterNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string ChapterTitle { get; set; }
        public int? ChapterExcercises { get; set; }
        public int? ChapterAllottedLectures { get; set; }
        public DifficultyLevel? DifficultyLevel { get; set; }
        public string? Topics { get; set; }
        public string? ChapterActivity { get; set; }
    }

    public class BookCreateDto
    {
        [Required]
        public string BookTitle { get; set; } = string.Empty;
        public string? NewPublisher { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
    public class BookUpdateDto
    {
        [Required]
        public string NewTitle { get; set; } = string.Empty;
        public string? NewPublisher { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
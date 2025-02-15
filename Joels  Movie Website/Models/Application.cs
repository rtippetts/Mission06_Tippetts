using System.ComponentModel.DataAnnotations;

namespace Joels__Movie_Website.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public bool? Lent_to { get; set; }

        [MaxLength(25)] // Enforce max length of 25 characters for Notes
        public string? Notes { get; set; }  // No [Required] attribute here
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joels__Movie_Website.Models
{
    public class Movie
    {
        [Key]
        public int? MovieId { get; set; }


        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        //[Required]
        public string? Title { get; set; }

        //[Required]
        
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int? Year { get; set; }


        //[Required]
        public string? Director { get; set; }

        //[Required]
        public string? Rating { get; set; }

        public int? Edited { get; set; }

        public string? LentTo { get; set; }

        public int? CopiedToPlex { get; set; }

        [MaxLength(25)] // Enforce max length of 25 characters for Notes
        public string? Notes { get; set; }  // No [Required] attribute here
    }
}

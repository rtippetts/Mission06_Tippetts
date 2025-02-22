using System.ComponentModel.DataAnnotations;

namespace Joels__Movie_Website.Models
{
    public class Category
    {
        [Key]
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}

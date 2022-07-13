using System.ComponentModel.DataAnnotations;

namespace AwesomeLibrary.API.Models
{
    public class BookPostDto
    {
        [Required(ErrorMessage = "You should provide a title for the book.")]
        [MaxLength(100, ErrorMessage = "You should provide a title that contains a maximum of 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public int Pages { get; set; }

        public string Publisher { get; set; } = string.Empty;
        public int PublishingYear { get; set; }
    }
}

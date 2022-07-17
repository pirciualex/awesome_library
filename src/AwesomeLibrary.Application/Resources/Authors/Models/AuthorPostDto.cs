using System.ComponentModel.DataAnnotations;

namespace AwesomeLibrary.Application.Resources.Authors.Models
{
    public class AuthorPostDto
    {
        [Required(ErrorMessage = "You should provide a first name for the author.")]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "You should provide a last name for the author.")]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "You should provide a birth date for the author.")]
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }
}

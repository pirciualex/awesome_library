namespace AwesomeLibrary.Application.Resources.Authors.Models
{
    public class AuthorGetDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }
}

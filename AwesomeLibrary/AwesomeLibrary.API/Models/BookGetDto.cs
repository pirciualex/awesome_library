namespace AwesomeLibrary.API.Models
{
    public class BookGetDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public int PublishingYear { get; set; }
    }
}

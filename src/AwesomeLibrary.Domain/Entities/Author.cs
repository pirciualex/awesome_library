using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public List<BookAuthor> BooksAuthors { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasData(new List<Author>
                {
                    new Author
                    {
                        Id = Guid.Parse("b4a4a08f-7a45-4f5d-8b01-8df88ddcb84a"),
                        FirstName = "Hermann",
                        LastName = "Hesse",
                        DateOfBirth = DateTime.Parse("1877-07-02"),
                        DateOfDeath = DateTime.Parse("1962-08-09")
                    },
                    new Author
                    {
                        Id = Guid.Parse("f1751877-39ce-4c58-b8be-8e7969a9cc16"),
                        FirstName = "Robert",
                        LastName = "Martin",
                        DateOfBirth = DateTime.Parse("1952-12-05")
                    },
                    new Author
                    {
                        Id = Guid.Parse("82815d61-6858-43b3-9104-07a4182b8ef6"),
                        FirstName = "Stephen",
                        LastName = "King",
                        DateOfBirth = DateTime.Parse("1947-09-21")
                    },
                    new Author
                    {
                        Id = Guid.Parse("2d02c1e4-9976-464e-a31c-4a3c8ff2b58b"),
                        FirstName = "Peter",
                        LastName = "Straub",
                        DateOfBirth = DateTime.Parse("1943-03-02")
                    },
                });
        }
    }
}

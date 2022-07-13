using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public int PublishingYear { get; set; }

        public List<BookAuthor> BooksAuthors { get; set; }

        public static void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Book>()
                .HasData(new List<Book>
                {
                    new Book
                    {
                        Id = Guid.Parse("498d1371-2cbe-4e36-8bd9-dcd041433d86"),
                        Title = "Siddhartha",
                        Genre = "Spiritality",
                        Pages = 216,
                        Publisher = "Rao",
                        PublishingYear = 2013
                    },
                    new Book
                    {
                        Id = Guid.Parse("e973d751-c737-4f42-bcd7-80ed8304e826"),
                        Title = "Clean Code",
                        Genre = "Programming",
                        Pages = 464,
                        Publisher = "Pearson Education",
                        PublishingYear = 2008
                    },
                    new Book
                    {
                        Id = Guid.Parse("fb7ac48e-6a30-426f-9ccc-e0a5659911e1"),
                        Title = "The Talisman",
                        Genre = "Fiction",
                        Pages = 992,
                        Publisher = "Orion Publishing",
                        PublishingYear = 2012
                    },
                    new Book
                    {
                        Id = Guid.Parse("35b4208e-a3b7-404d-aa08-d2db7a386776"),
                        Title = "The Shining",
                        Genre = "Horror",
                        Pages = 498,
                        Publisher = "Hodder & Stoughton Ltd",
                        PublishingYear = 2007
                    },
                });
        }
    }
}

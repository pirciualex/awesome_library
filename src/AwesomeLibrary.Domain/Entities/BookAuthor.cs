using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Domain.Entities
{
    public class BookAuthor
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }

        public static void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BooksAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelbuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BooksAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelbuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.AuthorId, ba.BookId });

            modelbuilder.Entity<BookAuthor>()
                .HasData(new List<BookAuthor>
                {
                    new BookAuthor
                    {
                        AuthorId = Guid.Parse("b4a4a08f-7a45-4f5d-8b01-8df88ddcb84a"),
                        BookId = Guid.Parse("498d1371-2cbe-4e36-8bd9-dcd041433d86")
                    },
                    new BookAuthor
                    {
                        AuthorId = Guid.Parse("f1751877-39ce-4c58-b8be-8e7969a9cc16"),
                        BookId = Guid.Parse("e973d751-c737-4f42-bcd7-80ed8304e826")
                    },
                    new BookAuthor
                    {
                        AuthorId = Guid.Parse("82815d61-6858-43b3-9104-07a4182b8ef6"),
                        BookId = Guid.Parse("fb7ac48e-6a30-426f-9ccc-e0a5659911e1")
                    },
                    new BookAuthor
                    {
                        AuthorId = Guid.Parse("82815d61-6858-43b3-9104-07a4182b8ef6"),
                        BookId = Guid.Parse("35b4208e-a3b7-404d-aa08-d2db7a386776")
                    },
                    new BookAuthor
                    {
                        AuthorId = Guid.Parse("2d02c1e4-9976-464e-a31c-4a3c8ff2b58b"),
                        BookId = Guid.Parse("fb7ac48e-6a30-426f-9ccc-e0a5659911e1")
                    },
                });
        }
    }
}

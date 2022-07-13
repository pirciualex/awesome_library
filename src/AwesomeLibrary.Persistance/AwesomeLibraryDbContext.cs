using AwesomeLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Persistance
{
    public class AwesomeLibraryDbContext : DbContext
    {
        public AwesomeLibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BooksAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Author.OnModelCreating(modelBuilder);
            Book.OnModelCreating(modelBuilder);
            BookAuthor.OnModelCreating(modelBuilder);
        }
    }
}

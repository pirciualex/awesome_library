using AwesomeLibrary.Application.Resources.BooksAuthors.Models;

namespace AwesomeLibrary.Application.Services.Interfaces
{
    public interface IBookAuthorService
    {
        Task<BookAuthorDto> LinkBookToAuthor(BookAuthorDto bookAuthor, CancellationToken cancellationToken);
    }
}

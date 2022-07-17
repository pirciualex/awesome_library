using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Resources.Books.Requests;
using AwesomeLibrary.Application.Resources.BooksAuthors.Models;

namespace AwesomeLibrary.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookGetDto> CreateBook(BookPostDto bookToAdd, CancellationToken cancellationToken);
        Task<BookWithAuthorsGetDto> GetBookWithAuthors(Guid bookId, CancellationToken cancellationToken);
    }
}

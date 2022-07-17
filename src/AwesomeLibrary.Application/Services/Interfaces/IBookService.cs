using AwesomeLibrary.Application.Resources.Books.Models;

namespace AwesomeLibrary.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookWithAuthorsDto> GetBookWithAuthors(Guid bookId, CancellationToken cancellationToken);
    }
}

using AwesomeLibrary.Application.Resources.Authors.Models;

namespace AwesomeLibrary.Application.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorGetDto> CreateAuthor(AuthorPostDto author, CancellationToken cancellationToken);
    }
}

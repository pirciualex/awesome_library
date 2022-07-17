using AwesomeLibrary.Application.Resources.Authors.Models;
using AwesomeLibrary.Application.Resources.Books.Models;

namespace AwesomeLibrary.Application.Resources.BooksAuthors.Models
{
    public class BookWithAuthorPostDto : BookPostDto
    {
        public IEnumerable<AuthorPostDto> Authors { get; set; }
    }
}

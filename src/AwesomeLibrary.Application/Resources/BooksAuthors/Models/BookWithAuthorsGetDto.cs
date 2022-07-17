using AwesomeLibrary.Application.Resources.Authors.Models;
using AwesomeLibrary.Application.Resources.Books.Models;

namespace AwesomeLibrary.Application.Resources.BooksAuthors.Models
{
    public class BookWithAuthorsGetDto : BookGetDto
    {
        public IEnumerable<AuthorGetDto> Authors { get; set; }
    }
}

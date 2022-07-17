using AwesomeLibrary.Application.Resources.Authors.Models;

namespace AwesomeLibrary.Application.Resources.Books.Models
{
    public class BookWithAuthorsDto : BookGetDto
    {
        public IEnumerable<AuthorGetDto> Authors { get; set; }
    }
}

using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Application.Resources.BooksAuthors.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeLibrary.API.Controllers
{
    [Route("api/booksauthors")]
    [ApiController]
    public class BooksAuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksAuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BookWithAuthorsGetDto>> LinkBookToAuthor(LinkBookToAuthorRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtRoute("GetBook", new { id = response.Id }, response);
        }

        [HttpPost("bookwithauthors")]
        public async Task<ActionResult<BookWithAuthorsGetDto>> CreateBookWithAuthors(CreateBookWithAuthorsRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtRoute("GetBook", new { id = response.Id }, response);
        }
    }
}

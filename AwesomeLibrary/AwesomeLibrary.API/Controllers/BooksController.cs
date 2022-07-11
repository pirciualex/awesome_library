using AwesomeLibrary.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeLibrary.API.Controllers
{
    // C - Create
    // R - Read
    // U - Update
    // D - Delete
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private static List<BookGetDto> _books = new List<BookGetDto>
        {
            new BookGetDto
            {
                Id = Guid.NewGuid(),
                Title = "White fang"
            },
            new BookGetDto
            {
                Id = Guid.Parse("e973d751-c737-4f42-bcd7-80ed8304e826"),
                Title = "Poetry book"
            },
        };

        public BooksController()
        {
        }

        [HttpPost]
        public ActionResult<BookGetDto> CreateBook(BookPostDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookId = Guid.NewGuid();
            var bookToAdd = new BookGetDto
            {
                Id = bookId,
                Title = book.Title,
                Genre = book.Genre,
                Pages = book.Pages,
                Publisher = book.Publisher,
                PublishingYear = book.PublishingYear,
            };

            _books.Add(bookToAdd);

            return CreatedAtRoute("GetBook", new { id = bookId }, bookToAdd);
        }

        [HttpGet()]
        public ActionResult<IEnumerable<BookGetDto>> GetAllBooks()
        {
            return Ok(_books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<BookGetDto> GetBook(Guid id)
        {
            var book = _books.SingleOrDefault(b => b.Id == id);
            if (book == default)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut("{id}")]
        public ActionResult FullyUpdateBook([FromRoute]Guid id, [FromBody]BookPostDto book)
        {
            var bookToUpdate = _books.SingleOrDefault(b => b.Id == id);
            if (bookToUpdate == default)
            {
                return NotFound();
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Genre = book.Genre;
            bookToUpdate.Pages = book.Pages;
            bookToUpdate.Publisher = book.Publisher;
            bookToUpdate.PublishingYear = book.PublishingYear;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateBook(Guid id, JsonPatchDocument<BookPostDto> patchDocument)
        {
            var bookToUpdate = _books.SingleOrDefault(b => b.Id == id);
            if (bookToUpdate == default)
            {
                return NotFound();
            }

            var bookUpdated = new BookPostDto
            {
                Title = bookToUpdate.Title,
                Genre = bookToUpdate.Genre,
                Pages = bookToUpdate.Pages,
                Publisher = bookToUpdate.Publisher,
                PublishingYear = bookToUpdate.PublishingYear,
            };

            patchDocument.ApplyTo(bookUpdated);
            bookToUpdate.Title = bookUpdated.Title;
            bookToUpdate.Genre = bookUpdated.Genre;
            bookToUpdate.Pages = bookUpdated.Pages;
            bookToUpdate.Publisher = bookUpdated.Publisher;
            bookToUpdate.PublishingYear = bookUpdated.PublishingYear;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var bookToUpdate = _books.SingleOrDefault(b => b.Id == id);
            if (bookToUpdate == default)
            {
                return NotFound();
            }

            _books.Remove(bookToUpdate);
            return NoContent();
        }
    }
}

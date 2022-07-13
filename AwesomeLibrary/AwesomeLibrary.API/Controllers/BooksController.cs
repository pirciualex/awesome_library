using AutoMapper;
using AwesomeLibrary.API.Entities;
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
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<BookGetDto> CreateBook(BookPostDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookToAdd = _mapper.Map<Book>(book);

            _context.Books.Add(bookToAdd);
            _context.SaveChanges();

            var bookToReturn = _mapper.Map<BookGetDto>(bookToAdd);

            return CreatedAtRoute("GetBook", new { id = bookToReturn.Id }, bookToReturn);
        }

        [HttpGet()]
        public ActionResult<IEnumerable<BookGetDto>> GetAllBooks()
        {
            return Ok(_mapper.Map<IEnumerable<BookGetDto>>(_context.Books.ToList()));
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<BookGetDto> GetBook(Guid id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == default)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookGetDto>(book));
        }

        [HttpPut("{id}")]
        public ActionResult FullyUpdateBook([FromRoute]Guid id, [FromBody]BookPostDto book)
        {
            var bookToUpdate = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookToUpdate == default)
            {
                return NotFound();
            }

            _mapper.Map(book, bookToUpdate);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateBook(Guid id, JsonPatchDocument<BookPostDto> patchDocument)
        {
            var bookToUpdate = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookToUpdate == default)
            {
                return NotFound();
            }

            var bookUpdated = _mapper.Map<BookPostDto>(bookToUpdate);
            patchDocument.ApplyTo(bookUpdated);
            _mapper.Map(bookUpdated, bookToUpdate);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var bookToUpdate = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookToUpdate == default)
            {
                return NotFound();
            }

            _context.Books.Remove(bookToUpdate);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

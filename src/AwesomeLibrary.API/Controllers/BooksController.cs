using AutoMapper;
using AwesomeLibrary.API.Models;
using AwesomeLibrary.Application.Resources.Books.Requests;
using AwesomeLibrary.Domain.Entities;
using AwesomeLibrary.Persistance;
using MediatR;
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
        private readonly IMediator _mediator;

        public BooksController(AwesomeLibraryDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BookGetDto>> CreateBook(CreateRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtRoute("GetBook", new { id = response.Id }, response);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<BookGetDto>>> GetAllBooks()
        {
            var response = await _mediator.Send(new GetAllRequest());
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public async Task<ActionResult<BookGetDto>> GetBook(Guid id)
        {
            var response = await _mediator.Send(new GetRequest { Id = id });
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult FullyUpdateBook([FromRoute] Guid id, [FromBody] BookPostDto book)
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

        #region LINQ
        //private static List<Book> _books = new List<Book>();
        private static List<Book> _books = new List<Book>
        {
            new Book
            {
                Id = Guid.Parse("498d1371-2cbe-4e36-8bd9-dcd041433d86"),
                Title = "Siddhartha",
                Genre = "Spiritality",
                Pages = 216,
                Publisher = "Rao",
                PublishingYear = 2013
            },
            new Book
            {
                Id = Guid.Parse("e973d751-c737-4f42-bcd7-80ed8304e826"),
                Title = "Clean Code",
                Genre = "Programming",
                Pages = 464,
                Publisher = "Pearson Education",
                PublishingYear = 2008
            },
            new Book
            {
                Id = Guid.Parse("fb7ac48e-6a30-426f-9ccc-e0a5659911e1"),
                Title = "The Talisman",
                Genre = "Horror",
                Pages = 992,
                Publisher = "Orion Publishing",
                PublishingYear = 2012
            },
            new Book
            {
                Id = Guid.Parse("35b4208e-a3b7-404d-aa08-d2db7a386776"),
                Title = "The Shining",
                Genre = "Horror",
                Pages = 498,
                Publisher = "Hodder & Stoughton Ltd",
                PublishingYear = 2007
            },
            new Book
            {
                Id = Guid.Parse("498d1371-2cbe-4e36-8bd9-dcd041433d86"),
                Title = "Siddhartha",
                Genre = "Spiritality",
                Pages = 216,
                Publisher = "Rao",
                PublishingYear = 2013
            },
            new Book
            {
                Id = Guid.Parse("e973d751-c737-4f42-bcd7-80ed8304e826"),
                Title = "Clean Code",
                Genre = "Programming",
                Pages = 464,
                Publisher = "Pearson Education",
                PublishingYear = 2008
            },
            new Book
            {
                Id = Guid.Parse("fb7ac48e-6a30-426f-9ccc-e0a5659911e1"),
                Title = "The Talisman",
                Genre = "Horror",
                Pages = 992,
                Publisher = "Orion Publishing",
                PublishingYear = 2012
            },
            new Book
            {
                Id = Guid.Parse("35b4208e-a3b7-404d-aa08-d2db7a386776"),
                Title = "The Shining",
                Genre = "Horror",
                Pages = 498,
                Publisher = "Hodder & Stoughton Ltd",
                PublishingYear = 2007
            },
            new Book
            {
                Id = Guid.Parse("498d1371-2cbe-4e36-8bd9-dcd041433d86"),
                Title = "Siddhartha",
                Genre = "Spiritality",
                Pages = 216,
                Publisher = "Rao",
                PublishingYear = 2013
            },
            new Book
            {
                Id = Guid.Parse("e973d751-c737-4f42-bcd7-80ed8304e826"),
                Title = "Clean Code",
                Genre = "Programming",
                Pages = 464,
                Publisher = "Pearson Education",
                PublishingYear = 2008
            },
            new Book
            {
                Id = Guid.Parse("fb7ac48e-6a30-426f-9ccc-e0a5659911e1"),
                Title = "The Talisman",
                Genre = "Horror",
                Pages = 992,
                Publisher = "Orion Publishing",
                PublishingYear = 2012
            },
            new Book
            {
                Id = Guid.Parse("35b4208e-a3b7-404d-aa08-d2db7a386776"),
                Title = "The Shining",
                Genre = "Horror",
                Pages = 498,
                Publisher = "Hodder & Stoughton Ltd",
                PublishingYear = 2007
            },
            new Book
            {
                Id = Guid.Parse("498d1371-2cbe-4e36-8bd9-dcd041433d86"),
                Title = "Siddhartha",
                Genre = "Spiritality",
                Pages = 216,
                Publisher = "Rao",
                PublishingYear = 2013
            },
            new Book
            {
                Id = Guid.Parse("e973d751-c737-4f42-bcd7-80ed8304e826"),
                Title = "Clean Code",
                Genre = "Programming",
                Pages = 464,
                Publisher = "Pearson Education",
                PublishingYear = 2008
            },
            new Book
            {
                Id = Guid.Parse("fb7ac48e-6a30-426f-9ccc-e0a5659911e1"),
                Title = "The Talisman",
                Genre = "Horror",
                Pages = 992,
                Publisher = "Orion Publishing",
                PublishingYear = 2012
            },
            new Book
            {
                Id = Guid.Parse("35b4208e-a3b7-404d-aa08-d2db7a386776"),
                Title = "The Shining",
                Genre = "Horror",
                Pages = 498,
                Publisher = "Hodder & Stoughton Ltd",
                PublishingYear = 2007
            },
        };

        [HttpGet("linq")]
        public IActionResult WorkWithLinq()
        {
            // FILTRARE
            //var book1 = _books.Single();
            //var book2 = _books.First();

            //var book3 = _books.SingleOrDefault();
            //var book4 = _books.FirstOrDefault();

            //var book5 = _books.SingleOrDefault(GetOneBook);
            //var book6 = _books.FirstOrDefault(book =>
            //{
            //    return book.Id.ToString() == "e973d751-c737-4f42-bcd7-80ed8304e826";
            //});
            //var book7 = _books.FirstOrDefault(book => book.Genre == "Horror");

            //var areThereAnyBooks1 = _books.Any();
            //var areThereAnyBooks2 = _books.Any(b => b.Genre == "Horror");

            // PROIECTIE
            //var books1 = _books.Where(b => b.Genre == "Horror" && b.Pages > 600);
            //var books2 = _books.Select(b => new { Title = b.Title, Genre = b.Genre });
            //var books3 = _books.Select(b => _mapper.Map<BookGetDto>(b));

            // ORDONARE
            //var books4 = _books.OrderBy(b => b.Title);
            //var books5 = _books.OrderByDescending(b => b.Pages);

            // AGREGARE
            //var aggregate1 = _books.Average(b => b.Pages);
            //var aggregate2 = _books.Min(b => b.Title.Length);
            //var aggregate3 = _books.Max(b => b.PublishingYear);
            //var aggregate4 = _books.Count();
            //var aggregateResult = new
            //{
            //    MeanNumberOfPages = aggregate1,
            //    TheShortestTitle = aggregate2,
            //    TheMostRecentPublishingYear = aggregate3,
            //    TotalBooksInCollection = aggregate4
            //}

            // PAGINARE
            var books6 = _context.Books.Skip(2);
            var books7 = _books.Take(3);

            // INLANTUIREA METODELOR
            int page = 2, pageSize = 5;
            var books8 = _books.Skip((page - 1) * pageSize).Take(pageSize);

            // DEFERRED EXECUTION
            var booksToProcess = _books.AsQueryable();
            booksToProcess = booksToProcess.Where(b => b.Genre == "Horror")
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize);

            // IMEDIATE EXECUTION - ToList, Count, Max, Min
            var books9 = booksToProcess.ToList();

            return Ok(books9);
        }

        private bool GetOneBook(Book book)
        {
            return book.Id.ToString() == "e973d751-c737-4f42-bcd7-80ed8304e826";
        }
        #endregion
    }
}

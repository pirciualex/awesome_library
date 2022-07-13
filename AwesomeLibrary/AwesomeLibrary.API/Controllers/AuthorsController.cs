using AutoMapper;
using AwesomeLibrary.API.Entities;
using AwesomeLibrary.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AwesomeLibrary.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AuthorGetDto> CreateAuthor(AuthorPostDto author)
        {
            var authorToAdd = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                DateOfDeath = author.DateOfDeath,
            };

            _context.Authors.Add(authorToAdd);
            _context.SaveChanges();

            var authorToReturn = new AuthorGetDto
            {
                Id = authorToAdd.Id,
                FullName = authorToAdd.FirstName + " " + authorToAdd.LastName,
                DateOfBirth = authorToAdd.DateOfBirth,
                DateOfDeath = authorToAdd.DateOfDeath,
            };

            return CreatedAtRoute("GetAuthor", new { id = authorToReturn.Id }, authorToReturn);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorGetDto>> GetAllAuthors()
        {
            return Ok(_mapper.Map<IEnumerable<AuthorGetDto>>(_context.Authors.ToList()));
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public ActionResult<AuthorGetDto> Get(Guid id)
        {
            var author = _context.Authors.SingleOrDefault(b => b.Id == id);
            if (author == default)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorGetDto>(author));
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, AuthorPostDto author)
        {
            var authorToUpdate = _context.Authors.SingleOrDefault(b => b.Id == id);
            if (authorToUpdate == default)
            {
                return NotFound();
            }

            authorToUpdate.FirstName = author.FirstName;
            authorToUpdate.LastName = author.LastName;
            authorToUpdate.DateOfBirth = author.DateOfBirth;
            authorToUpdate.DateOfDeath = author.DateOfDeath;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateBook(Guid id, JsonPatchDocument<AuthorPostDto> patchDocument)
        {
            var authorToUpdate = _context.Authors.SingleOrDefault(b => b.Id == id);
            if (authorToUpdate == default)
            {
                return NotFound();
            }

            var authorUpdated = new AuthorPostDto
            {
                FirstName = authorToUpdate.FirstName,
                LastName = authorToUpdate.LastName,
                DateOfBirth = authorToUpdate.DateOfBirth,
                DateOfDeath = authorToUpdate.DateOfDeath,
            };

            patchDocument.ApplyTo(authorUpdated);

            authorToUpdate.FirstName = authorUpdated.FirstName;
            authorToUpdate.LastName = authorUpdated.LastName;
            authorToUpdate.DateOfBirth = authorUpdated.DateOfBirth;
            authorToUpdate.DateOfDeath = authorUpdated.DateOfDeath;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var authorToDelete = _context.Authors.SingleOrDefault(b => b.Id == id);
            if (authorToDelete == default)
            {
                return NotFound();
            }

            _context.Authors.Remove(authorToDelete);
            return NoContent();
        }
    }
}

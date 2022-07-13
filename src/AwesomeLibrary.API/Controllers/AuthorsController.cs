using AutoMapper;
using AwesomeLibrary.API.Models;
using AwesomeLibrary.Domain.Entities;
using AwesomeLibrary.Persistance;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

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
            var authorToAdd = _mapper.Map<Author>(author);
            _context.Authors.Add(authorToAdd);
            _context.SaveChanges();
            var authorToReturn = _mapper.Map<AuthorGetDto>(authorToAdd);
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

            _mapper.Map(author, authorToUpdate);
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

            var authorUpdated = _mapper.Map<AuthorPostDto>(authorToUpdate);
            patchDocument.ApplyTo(authorUpdated);
            _mapper.Map(authorUpdated, authorToUpdate);
            _context.SaveChanges();
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
            _context.SaveChanges();
            return NoContent();
        }
    }
}

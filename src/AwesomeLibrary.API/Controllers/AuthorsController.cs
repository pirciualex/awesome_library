using AutoMapper;
using AwesomeLibrary.API.Models;
using AwesomeLibrary.Application.Resources.Authors.Requests;
using AwesomeLibrary.Persistance;
using MediatR;
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
        private readonly IMediator _mediator;

        public AuthorsController(AwesomeLibraryDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorGetDto>> CreateAuthor(CreateRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtRoute("GetAuthor", new { id = response.Id }, response);
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

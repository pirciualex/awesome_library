using AutoMapper;
using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Application.Resources.Books.Requests
{
    public class GetAllRequest : IRequest<IEnumerable<BookWithAuthorsGetDto>>
    {
    }

    public class GetAllRequestHandler : IRequestHandler<GetAllRequest, IEnumerable<BookWithAuthorsGetDto>>
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRequestHandler(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookWithAuthorsGetDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var books = await
                _context.Books
                .Include(b => b.BooksAuthors)
                .ThenInclude(ba => ba.Author)
                .ToListAsync();
            return _mapper.Map<IEnumerable<BookWithAuthorsGetDto>>(books);
        }
    }
}

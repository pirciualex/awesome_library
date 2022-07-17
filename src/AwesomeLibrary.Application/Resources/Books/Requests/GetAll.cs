using AutoMapper;
using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Application.Resources.Books.Requests
{
    public class GetAllRequest : IRequest<IEnumerable<BookGetDto>>
    {
    }

    public class GetAllRequestHandler : IRequestHandler<GetAllRequest, IEnumerable<BookGetDto>>
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRequestHandler(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookGetDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var books = await
                _context.Books
                .Include(b => b.BooksAuthors)
                .ThenInclude(ba => ba.Author)
                .ToListAsync();
            return _mapper.Map<IEnumerable<BookWithAuthorsDto>>(books);
        }
    }
}

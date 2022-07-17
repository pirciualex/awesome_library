using AutoMapper;
using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Common.Exceptions;
using AwesomeLibrary.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Application.Resources.Books.Requests
{
    public class GetRequest : IRequest<BookGetDto>
    {
        public Guid Id { get; set; }
    }

    public class GetRequestHandler : IRequestHandler<GetRequest, BookGetDto>
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetRequestHandler(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookGetDto> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            if (book == default)
            {
                throw new NotFoundException("The book you requested was not found");
            }

            return _mapper.Map<BookGetDto>(book);
        }
    }
}

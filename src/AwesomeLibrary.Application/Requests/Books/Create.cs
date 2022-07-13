using AutoMapper;
using AwesomeLibrary.API.Models;
using AwesomeLibrary.Domain.Entities;
using AwesomeLibrary.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeLibrary.Application.Requests.Books
{
    public class CreateRequest : BookPostDto, IRequest<BookGetDto>
    {
    }

    public class CreateRequestHandler : IRequestHandler<CreateRequest, BookGetDto>
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public CreateRequestHandler(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookGetDto> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var bookToAdd = _mapper.Map<Book>(request);

            _context.Books.Add(bookToAdd);
            await _context.SaveChangesAsync();

            var bookToReturn = _mapper.Map<BookGetDto>(bookToAdd);
            return bookToReturn;
        }
    }
}

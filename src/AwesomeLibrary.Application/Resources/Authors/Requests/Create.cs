using AwesomeLibrary.Application.Resources.Authors.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using MediatR;

namespace AwesomeLibrary.Application.Resources.Authors.Requests
{
    public class CreateRequest : AuthorPostDto, IRequest<AuthorGetDto>
    {
    }

    public class CreateRequestHandler : IRequestHandler<CreateRequest, AuthorGetDto>
    {
        private readonly IAuthorService _authorService;

        public CreateRequestHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<AuthorGetDto> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            return await _authorService.CreateAuthor(request, cancellationToken);
        }
    }
}

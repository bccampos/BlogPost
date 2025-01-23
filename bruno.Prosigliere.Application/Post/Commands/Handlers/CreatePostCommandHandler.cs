using bruno.Prosigliere.Domain.Interfaces.Persistence;
using FluentResults;
using MediatR;

namespace bruno.Prosigliere.Application.Post.Commands.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result>
    {
        private readonly IBlogPostRepository _postRepository;

        public CreatePostCommandHandler(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Domain.Entities.BlogPost().Create(request.Title, request.Content, null);

            _postRepository.Add(post);

            await _postRepository.CommitAsync();

            return Result.Ok();
        }
    }
}

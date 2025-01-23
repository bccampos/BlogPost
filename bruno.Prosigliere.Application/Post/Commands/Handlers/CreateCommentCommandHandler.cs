using bruno.Prosigliere.Domain;
using bruno.Prosigliere.Domain.Interfaces.Persistence;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bruno.Prosigliere.Application.Post.Commands.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result>
    {
        private readonly IBlogPostRepository _postRepository;

        public CreateCommentCommandHandler(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var postResult = await _postRepository.GetByIdAsync(request.PostId);

            if (postResult is null)
            {
                return Result.Fail($"Post {request.PostId} does not exist");
            }

            var comment = new Domain.Entities.Comment().Create(request.Comment);
            postResult.AddComment(comment);

            await _postRepository.CommitAsync();

            return Result.Ok();
        }

    }
}

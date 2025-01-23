using bruno.Prosigliere.Domain.Interfaces.Persistence;
using FluentResults;
using MediatR;

namespace bruno.Prosigliere.Application.Post.Queries.Handlers
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Result<PostResponse>>
    {
        private readonly IBlogPostRepository _postRepository;

        public GetPostByIdQueryHandler(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<PostResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _postRepository.GetByIdAsync(request.Id);

            if (result is null)
            {
                return Result.Fail($"Post {request.Id} does not exist");
            }

            var postResponses = new PostResponse
            {
                Id = result.Id.Value,
                Title = result.Title,
                Content = result.Content,
                CommentCount = result.Comments?.Count ?? 0,
                Comments = result.Comments?.Select(c => new Comment
                {
                    Id = c.Id.Value,
                    Content = c.Content
                }).ToList() ?? new List<Comment>()
            };

            return Result.Ok(postResponses);
        }
    }
}

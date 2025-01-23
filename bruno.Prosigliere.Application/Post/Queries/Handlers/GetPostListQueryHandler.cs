using bruno.Prosigliere.Domain.Interfaces.Persistence;
using FluentResults;
using MediatR;

namespace bruno.Prosigliere.Application.Post.Queries.Handlers
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, Result<List<PostResponse>>>
    {
        private readonly IBlogPostRepository _postRepository;

        public GetPostListQueryHandler(IBlogPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<List<PostResponse>>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var result = await _postRepository.GetAllAsync();

            var postResponses = result.Select(p => new PostResponse
            {
                Id = p.Id.Value,
                Title = p.Title,
                Content = p.Content,
                CommentCount = p.Comments?.Count ?? 0,
                Comments = p.Comments?.Select(c => new Comment
                {
                    Id = c.Id.Value,
                    Content = c.Content
                }).ToList() ?? new List<Comment>()
            }).ToList();

            return Result.Ok(postResponses);
        }
    }
}

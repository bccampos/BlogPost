using MediatR;
using FluentResults;

namespace bruno.Prosigliere.Application.Post.Queries
{
    public record GetPostListQuery : IRequest<Result<List<PostResponse>>>;
}

using MediatR;
using FluentResults;

namespace bruno.Prosigliere.Application.Post.Queries
{
    public record GetPostByIdQuery(Guid Id) : IRequest<Result<PostResponse>>;
}

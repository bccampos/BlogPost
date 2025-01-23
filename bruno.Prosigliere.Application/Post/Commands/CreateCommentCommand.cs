using FluentResults;
using MediatR;

namespace bruno.Prosigliere.Application.Post.Commands
{
    public record CreateCommentCommand(
        Guid PostId,
        string Comment
        ) : IRequest<Result>;
}

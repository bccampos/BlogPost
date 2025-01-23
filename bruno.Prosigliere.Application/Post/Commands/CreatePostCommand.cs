using FluentResults;
using MediatR;

namespace bruno.Prosigliere.Application.Post.Commands
{
    public record CreatePostCommand(
        string Title, 
        string Content
        ) : IRequest<Result>;
}

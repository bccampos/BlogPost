using bruno.Prosigliere.Application.Post.Commands;
using bruno.Prosigliere.Application.Post.Commands.Handlers;
using bruno.Prosigliere.Domain.Entities;
using bruno.Prosigliere.Domain.Interfaces.Persistence;
using FluentAssertions;
using FluentResults;
using Moq;
using NSubstitute;

namespace bruno.Prosigliere.Application.Tests
{
    public class CreateCommentCommandHandlerTests
    {
        private readonly Mock<IBlogPostRepository> _mockRepository;
        private readonly CreateCommentCommandHandler _handler;

        public CreateCommentCommandHandlerTests()
        {
            _mockRepository = new Mock<IBlogPostRepository>();
            _handler = new CreateCommentCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task ShouldCreateCommentWithSuccess()
        {
            var comment = new Comment().Create("content 1");
            var post = new BlogPost().Create("bruno", "campos", comment);

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(post);

            var command = new CreateCommentCommand(post.Id.Value, "content 2");

            Result response = await _handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_Add_Comment_When_Post_Exists()
        {
            var postId = Guid.NewGuid();
            var command = new CreateCommentCommand(postId, "Comment 1");

            var mockPost = new Domain.Entities.BlogPost { Id = Domain.PostId.Parse(postId), Title = "Test", Content = "Content" };

            _mockRepository.Setup(repo => repo.GetByIdAsync(postId))
                .ReturnsAsync(mockPost);

            _mockRepository.Setup(repo => repo.CommitAsync())
                .Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeTrue();
            mockPost.Comments.Should().HaveCount(1);
            mockPost.Comments[0].Content.Should().Be(command.Comment);

            _mockRepository.Verify(repo => repo.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_Fail_When_Post_Not_Found()
        {
            var command = new CreateCommentCommand(Guid.NewGuid(), "Comment 1");

            _mockRepository.Setup(repo => repo.GetByIdAsync(command.PostId))
                .ReturnsAsync((Domain.Entities.BlogPost)null);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.Message.Equals($"Post {command.PostId} does not exist"));
        }

    }
}
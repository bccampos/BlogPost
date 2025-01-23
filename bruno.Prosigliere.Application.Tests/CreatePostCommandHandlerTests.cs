using bruno.Prosigliere.Application.Post.Commands;
using bruno.Prosigliere.Application.Post.Commands.Handlers;
using bruno.Prosigliere.Domain.Interfaces.Persistence;
using FluentResults;
using NSubstitute;
using FluentAssertions;
using Moq;

namespace bruno.Prosigliere.Application.Tests
{
    public class CreatePostCommandHandlerTests
    {
        private readonly Mock<IBlogPostRepository> _mockRepository;
        private readonly CreatePostCommandHandler _handler;

        public CreatePostCommandHandlerTests()
        {
            _mockRepository = new Mock<IBlogPostRepository>();
            _handler = new CreatePostCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task ShouldCreateBlogPostWithSuccess()
        {
            var command = new CreatePostCommand("Title Post", "Content Post");

            Result response = await _handler.Handle(command, CancellationToken.None);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();

            _mockRepository.Verify(repo => repo.Add(It.IsAny<Domain.Entities.BlogPost>()), Times.Once);
            _mockRepository.Verify(repo => repo.CommitAsync(), Times.Once);
        }
    }
}
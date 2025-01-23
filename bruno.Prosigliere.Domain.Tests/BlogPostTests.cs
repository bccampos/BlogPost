using bruno.Prosigliere.Domain.Entities;
using FluentAssertions;

namespace bruno.Prosigliere.Domain.Tests
{
    public class BlogPostTests
    {
        [Fact]
        public void Create_Should_Create_BlogPost_With_Valid_Data()
        {
            // Arrange
            var title = "Test Title";
            var content = "Test Content";
            Comment? comment = null;

            // Act
            var blogPost = new BlogPost().Create(title, content, comment);

            // Assert
            blogPost.Should().NotBeNull();
            blogPost.Title.Should().Be(title);
            blogPost.Content.Should().Be(content);
            blogPost.Comments.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Create_Should_Add_Comment_If_Provided()
        {
            var title = "Test Title";
            var content = "Test Content";
            var comment = new Comment().Create("Test Comment");

            var blogPost = new BlogPost().Create(title, content, comment);

            blogPost.Should().NotBeNull();
            blogPost.Title.Should().Be(title);
            blogPost.Content.Should().Be(content);
            blogPost.Comments.Should().HaveCount(1);
            blogPost.Comments[0].Content.Should().Be(comment.Content);
        }

        [Fact]
        public void AddComment_Should_Add_Comment_To_Comments_List()
        {
            // Arrange
            var blogPost = new BlogPost().Create("Test Title", "Test Content", null);
            var comment = new Comment().Create("New Comment");

            // Act
            blogPost.AddComment(comment);

            // Assert
            blogPost.Comments.Should().HaveCount(1);
            blogPost.Comments[0].Content.Should().Be(comment.Content);
        }

        [Fact]
        public void AddComment_Should_Initialize_Comments_List_If_Null()
        {
            var blogPost = new BlogPost();
            var comment = new Comment().Create("New Comment");

            blogPost.AddComment(comment);

            blogPost.Comments.Should().NotBeNull();
            blogPost.Comments.Should().HaveCount(1);
            blogPost.Comments[0].Content.Should().Be(comment.Content);
        }
    }
}
using bruno.Prosigliere.Domain;
using bruno.Prosigliere.Domain.Entities;
using bruno.Prosigliere.Domain.Interfaces.Persistence;

namespace bruno.Prosigliere.Infrastructure.Repositories
{
    public class FakeBlogPostRepository : IBlogPostRepository
    {
        private readonly static List<BlogPost> _existing = GetFakeBlogPosts();

        public int CommitCalledCount { get; set; }
        public int DeleteCalledCount { get; set; }

        public FakeBlogPostRepository()
        {
        }

        public Task<List<BlogPost>> GetAllAsync()
        {
            return Task.FromResult(_existing);
        }

        public Task<BlogPost> GetByIdAsync(Guid PostId)
        {
            return Task.FromResult(_existing.Find(e => e.Id.Value.Equals(PostId)));
        }

        public void Add(BlogPost post)
        {
            _existing.Add(post);
        }

        public void AddComment(Guid postId, Comment comment)
        {
            var post = _existing.Find(e => e.Id.Value.Equals(postId));
            if (post != null)
            {
                post.Comments.Add(comment);
            }
        }

        public Task CommitAsync()
        {
            CommitCalledCount++;
            return Task.CompletedTask;
        }

        private static List<BlogPost> GetFakeBlogPosts()
        {
            return new List<BlogPost>()
            {
                new BlogPost().Create("Post Test 1", "Content", new Comment().Create("Comment")),
                new BlogPost().Create("Post Test 2", "Content", new Comment().Create("Comment"))
            };
        }
    }
}

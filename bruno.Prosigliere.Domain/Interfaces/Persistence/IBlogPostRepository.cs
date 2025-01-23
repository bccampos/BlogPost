using bruno.Prosigliere.Domain.Entities;

namespace bruno.Prosigliere.Domain.Interfaces.Persistence
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost> GetByIdAsync(Guid postId);
        void Add(BlogPost post);
        void AddComment(Guid postId, Comment comment);
        Task CommitAsync();
    }
}

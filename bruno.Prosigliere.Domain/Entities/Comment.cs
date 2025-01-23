using bruno.Prosigliere.Domain.Models;
using System.Net.Http.Headers;

namespace bruno.Prosigliere.Domain.Entities
{
    public class Comment : Entity<CommentId>
    {
        public CommentId Id { get; set; }
        public string Content { get; private set; }

        public Comment() { }

        private Comment(CommentId id, string content) : base(id)
        {
            Id = id;
            Content = content; 
        }

        public Comment Create(string content)
        {
            return new Comment(CommentId.Create(), content);
        }
    }
}

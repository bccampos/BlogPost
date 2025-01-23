using bruno.Prosigliere.Domain.Models;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace bruno.Prosigliere.Domain.Entities
{
    public class BlogPost : Entity<PostId>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; private set; }

        public BlogPost() { }

        private BlogPost(PostId id, string title, string content, Comment? comment) : base(id)
        {
            Title = title;
            Content = content;

            if (comment is not null)
            {
                Comments = new List<Comment>();
                AddComment(comment);
            }              
        }

        public BlogPost Create(string title, string content, Comment? comment)
        {
            return new BlogPost(PostId.Create(), title, content, comment);
        }
        public void AddComment(Comment comment)
        {
            if (Comments is null)
                Comments = new List<Comment>();

            Comments.Add(comment);
        }
    }
}

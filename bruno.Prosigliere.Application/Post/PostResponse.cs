namespace bruno.Prosigliere.Application.Post
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentCount { get; set; }
        public List<Comment> Comments { get; set; } = new();
    }

    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}

using bruno.Prosigliere.Domain.Models;

namespace bruno.Prosigliere.Domain
{
    public class CommentId : ValueObject
    {
        public Guid Value { get; }

        private CommentId()
        {
        }

        private CommentId(Guid value)
        {
            Value = value;
        }

        public static CommentId Create()
        {
            return new(Guid.NewGuid());
        }

        public static CommentId Create(Guid Value)
        {
            return new CommentId(Value);
        }

        public static CommentId Parse(Guid value)
        {
            return new CommentId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

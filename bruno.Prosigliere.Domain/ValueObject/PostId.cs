using bruno.Prosigliere.Domain.Models;

namespace bruno.Prosigliere.Domain
{
    public class PostId : ValueObject
    {
        public Guid Value { get; set; }

        private PostId()
        {
        }

        private PostId(Guid value)
        {
            Value = value;
        }

        public static PostId Create()
        {
            return new(Guid.NewGuid());
        }

        public static PostId Create(Guid Value)
        {
            return new PostId(Value);
        }

        public static PostId Parse(Guid value)
        {
            return new PostId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

namespace bruno.Prosigliere.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync(); 
    }
}

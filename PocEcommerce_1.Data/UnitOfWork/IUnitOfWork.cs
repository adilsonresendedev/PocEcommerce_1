namespace PocEcommerce_1.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task SaveChangesAsync();
        Task Rollback();
    }
}

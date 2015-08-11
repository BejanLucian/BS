namespace TaskPlanner.Infrastructure.Context
{
    public interface IDataContextFactory
    {
        IDbContext Create<T>() where T : IDbContext;
    }
}

namespace TaskPlanner.Infrastructure.Context
{
    public interface IDataContextFactory
    {
        T Create<T>();
    }
}

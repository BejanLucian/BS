namespace TaskPlanner.Infrastructure.Context
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetCurrent();
    }
}
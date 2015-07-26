namespace TaskPlanner.Domain.StorageIoc
{
    public interface IRepository<in T>
    {
        void Add(T task);

        void Remove(T task);
    }
}

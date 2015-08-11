namespace TaskPlanner.Domain.StorageIoc
{
    public interface IRepository<in T> where T:class 
    {
        void Add(T task);

        void Remove(T task);
    }
}

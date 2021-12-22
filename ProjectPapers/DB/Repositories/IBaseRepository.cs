namespace ProjectPapers.DB.Repositories
{
    public interface IBaseRepository<T, Z>
    {
        Task<T?> GetById(Z entityId);
        Task<T> Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}

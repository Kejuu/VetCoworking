namespace VetCoworking.Domain.Abstractions
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}

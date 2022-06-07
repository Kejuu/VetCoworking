namespace VetCoworking.Domain.Abstractions
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
    }
}

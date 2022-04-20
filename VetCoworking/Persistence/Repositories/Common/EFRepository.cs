using Microsoft.EntityFrameworkCore;
using VetCoworking.Domain.Abstractions;

namespace VetCoworking.Persistence.Repositories.Common
{
    public abstract class EFRepository<TEntity, TDbContext> : IAsyncRepository<TEntity>, IEFRepository<TEntity> where TEntity : class where TDbContext : DbContext
    {
        protected TDbContext _dbContext;

        protected EFRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<IReadOnlyList<TEntity>> ListAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}



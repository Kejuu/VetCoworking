using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

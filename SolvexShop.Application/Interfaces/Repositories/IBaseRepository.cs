using SolvexShop.Core.Domain.Result;

namespace SolvexShop.Core.Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TId>
    {
        Task<OperationResult<TEntity>> AddAsync(TEntity entity);
        Task<OperationResult<TEntity>> GetByIdAsync(TId id);
        Task<OperationResult<IQueryable<TEntity>>> GetAllAsync();
        Task<OperationResult<TEntity>> UpdateAsync(TEntity entity);
        Task<OperationResult<TEntity>> DeleteAsync(TEntity entity);
    }
}

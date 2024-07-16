
namespace HR_LeaveManagement.Application.Persistence.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity>AddAsync(TEntity entity);
        Task<bool>Exists(int id);   
        Task<TEntity>UpdateAsync(TEntity entity);
        Task<TEntity>DeleteAsync(TEntity entity);
    }
}

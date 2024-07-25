
namespace HR_LeaveManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetLeaveAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllLeaveAsync();
        Task<TEntity> AddLeaveAsync(TEntity entity);
        Task<bool>Exists(int id);   
        Task UpdateLeaveAsync(TEntity entity);
        Task DeleteLeaveAsync(TEntity entity);
    }
}

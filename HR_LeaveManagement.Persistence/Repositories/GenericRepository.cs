using HR_LeaveManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HR_LeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _context;

        public GenericRepository(LeaveManagementDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddLeaveAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteLeaveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task<bool> Exists(int id)
        {
           var entity = await GetLeaveAsync(id);
           return entity != null;
        }

        public async Task<IReadOnlyList<T>> GetAllLeaveAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetLeaveAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task UpdateLeaveAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;    
            await _context.SaveChangesAsync();
        }
    }
}

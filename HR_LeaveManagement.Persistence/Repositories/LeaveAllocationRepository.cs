using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;

namespace HR_LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _context;
        public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LeaveAllocation>> GetAllListAllocationAsync()
        {
          /*  var leaveAllocations = await _context.LeaveAllocations
                .Include(q=>q.LeaveType).ToListAsync();
            return leaveAllocations;*/
            throw new NotImplementedException();
        }

        public Task<LeaveAllocation> GetListAllocationAsyncById(int id)
        {
          /*  var leaveAllocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType).FirstOrDefaultAsync(q=>q.Id==id);
            return leaveAllocations;*/
            throw new NotImplementedException();
        }
    }
}

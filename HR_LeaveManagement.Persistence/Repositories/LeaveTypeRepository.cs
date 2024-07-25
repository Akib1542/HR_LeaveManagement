using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;

namespace HR_LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>,ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveTypeRepository(LeaveManagementDbContext context): base(context)
        {
            _context = context;
        }
    }
}

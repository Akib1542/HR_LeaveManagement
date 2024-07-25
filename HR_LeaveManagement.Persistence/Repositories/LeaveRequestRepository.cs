using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository:GenericRepository<LeaveRequest>,ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveRequestRepository(LeaveManagementDbContext context):base(context)
        {
            _context = context;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _context.Entry(leaveRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestAsync()
        {
         /*   var leaveRequests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync(); 
            return leaveRequests;*/
            throw new NotImplementedException();
        }

        public Task<LeaveRequest> GetLeaveRequestByIdAsync(int id)
        {
           /* var leaveRequest = await _context.LeaveRequests
              .Include(q => q.LeaveType)
              .FirstOrDefalutAsync(q=> q.Id == id);
            return leaveRequest;*/
            throw new NotImplementedException();
        }
    }
}

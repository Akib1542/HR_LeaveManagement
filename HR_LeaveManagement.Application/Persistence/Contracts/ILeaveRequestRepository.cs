using HR_LeaveManagement.Domain;

namespace HR_LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest>GetLeaveRequestByIdAsync(int id);
        Task<List<LeaveRequest>> GetAllLeaveRequestAsync();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}

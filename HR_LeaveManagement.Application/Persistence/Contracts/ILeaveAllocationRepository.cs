using HR_LeaveManagement.Domain;

namespace HR_LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetAllListAllocationAsync();
        Task<LeaveAllocation>GetListAllocationAsyncById(int id);
    }
}

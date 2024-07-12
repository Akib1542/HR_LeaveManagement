using HR_LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationRequestById : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}

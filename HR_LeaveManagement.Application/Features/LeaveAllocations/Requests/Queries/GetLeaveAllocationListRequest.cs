using HR_LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest:IRequest<List<LeaveAllocationDto>>
    {
    }
}

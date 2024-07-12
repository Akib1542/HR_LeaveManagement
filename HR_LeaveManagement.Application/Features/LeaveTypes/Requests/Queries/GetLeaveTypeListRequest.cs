using HR_LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}

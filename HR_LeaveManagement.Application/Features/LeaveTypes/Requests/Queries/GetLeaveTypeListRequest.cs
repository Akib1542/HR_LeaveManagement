using HR_LeaveManagement.Application.DTOs;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}

using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Request.Queries
{
    public class GetLeaveRequestDetailsById:IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}

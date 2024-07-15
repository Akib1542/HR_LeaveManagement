using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public CreateLeaveRequestDto LeaveRequestdto { get; set; }
    }
}

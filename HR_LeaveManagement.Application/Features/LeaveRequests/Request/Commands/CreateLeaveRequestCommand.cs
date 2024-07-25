using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using HR_LeaveManagement.Application.Responses;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponses>
    {
        public CreateLeaveRequestDto LeaveRequestdto { get; set; }
    }
}

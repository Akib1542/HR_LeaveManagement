
using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
        public UpdateLeaveRequestDto updateLeaveRequestDto { get; set; }    
        public ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto { get; set;}
    }
}

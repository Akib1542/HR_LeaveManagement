using HR_LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand:IRequest<int>
    {
        public CreateLeaveTypeDto leaveTypeDto { get; set; }
    }
}

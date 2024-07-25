using HR_LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDto LeaveType { get; set; } 
    }
}

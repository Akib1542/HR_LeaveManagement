using HR_LeaveManagement.Application.DTOs.Common;
using HR_LeaveManagement.Application.DTOs.LeaveType;

namespace HR_LeaveManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}

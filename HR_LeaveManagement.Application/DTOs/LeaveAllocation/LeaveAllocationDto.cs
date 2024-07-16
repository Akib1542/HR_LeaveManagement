using HR_LeaveManagement.Application.DTOs.Common;
using HR_LeaveManagement.Application.DTOs.LeaveType;

namespace HR_LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto , ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

    }
}

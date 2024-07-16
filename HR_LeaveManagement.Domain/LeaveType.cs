using HR_LeaveManagement.Domain.Common;

namespace HR_LeaveManagement.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }    
        public int DefaultDays { get; set; }
    }
}

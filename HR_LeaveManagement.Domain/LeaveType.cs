using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Domain
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

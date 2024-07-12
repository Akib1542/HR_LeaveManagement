using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequestDetailsById:IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}

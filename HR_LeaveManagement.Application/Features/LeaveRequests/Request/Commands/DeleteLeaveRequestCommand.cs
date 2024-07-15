﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands
{
    public class DeleteLeaveRequestCommand: IRequest
    {
        public int Id { get; set; } 
    }
}
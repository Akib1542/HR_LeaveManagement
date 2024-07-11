﻿
using HR_LeaveManagement.Application.DTOs;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeRequestById : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
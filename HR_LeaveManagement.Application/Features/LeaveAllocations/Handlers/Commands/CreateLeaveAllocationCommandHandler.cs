﻿using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR_LeaveManagement.Application.Exceptions;
using HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator =  new CreateLeaveAllocationValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveAllocation);
            if(!validationResult.IsValid)
            {
                throw new ValidationExceptions(validationResult);
            }
            var leaveAllocationInDb = _mapper.Map<LeaveAllocation>(request.leaveAllocation);
            leaveAllocationInDb = await _leaveAllocationRepository.AddLeaveAsync(leaveAllocationInDb);
            return leaveAllocationInDb.Id;
        }
    }
}

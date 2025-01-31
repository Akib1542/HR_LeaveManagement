﻿
using FluentValidation;
using HR_LeaveManagement.Application.Contracts.Persistence;

namespace HR_LeaveManagement.Application.DTOs.LeaveRequest.Validator
{
    public class ILeaveRequestDtoValidator:AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p=>p.StartDate)
                .LessThan(p=>p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");


            RuleFor(p=>p.EndDate)
                 .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveExists = await _leaveTypeRepository.Exists(id);
                    return !leaveExists;
                }).WithMessage("{PropertyName} does not exist!");
        }
    }
}

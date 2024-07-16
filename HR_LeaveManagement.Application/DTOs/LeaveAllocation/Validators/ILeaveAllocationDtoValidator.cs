
using FluentValidation;
using HR_LeaveManagement.Application.Persistence.Contracts;

namespace HR_LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator:AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} greater than 0!");


            RuleFor(p => p.Period)
                 .NotNull().WithMessage("{PropertyName} must not be null!");

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

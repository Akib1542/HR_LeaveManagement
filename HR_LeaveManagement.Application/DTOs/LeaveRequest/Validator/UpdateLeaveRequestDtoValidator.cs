using FluentValidation;
using HR_LeaveManagement.Application.Contracts.Persistence;


namespace HR_LeaveManagement.Application.DTOs.LeaveRequest.Validator
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present!");
        }
    }
}

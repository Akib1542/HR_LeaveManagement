
using FluentValidation;

namespace HR_LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator: AbstractValidator <LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage("{PropertyName} must be present!");
        }
    }
}

using FluentValidation;
using HR_LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR_LeaveManagement.Application.Persistence.Contracts;

namespace HR_LeaveManagement.Application.DTOs.LeaveRequest.Validator
{
    public class CreateLeaveRequestValidator:AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));  
        }
    }
}

using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR_LeaveManagement.Application.Persistence.Contracts;
using HR_LeaveManagement.Domain;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.LeaveTypeDto);
            if (!validatorResult.IsValid)
            {
                throw new Exception();
            }
            var leaveTypeInDb = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            leaveTypeInDb = await _leaveTypeRepository.AddAsync(leaveTypeInDb);
            return leaveTypeInDb.Id;    
        }
    }
}

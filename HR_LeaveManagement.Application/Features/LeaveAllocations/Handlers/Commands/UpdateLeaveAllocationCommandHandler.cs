using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR_LeaveManagement.Application.DTOs.LeaveRequest.Validator;
using HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR_LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatoionResult = await validator.ValidateAsync(request.leaveAllocationDto);
            if (!validatoionResult.IsValid)
            {
                throw new Exception();
            }

            var updateLeaveAllocation = await _leaveAllocationRepository.GetAsync(request.leaveAllocationDto.Id);
            _mapper.Map(request.leaveAllocationDto, updateLeaveAllocation);
            await _leaveAllocationRepository.UpdateAsync(updateLeaveAllocation);
            return Unit.Value;
        }
    }
}

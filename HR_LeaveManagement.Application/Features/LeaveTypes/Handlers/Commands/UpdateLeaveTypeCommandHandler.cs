using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR_LeaveManagement.Application.Exceptions;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validatoionResult = await validator.ValidateAsync(request.LeaveType);
            if(!validatoionResult.IsValid)
            {
                throw new ValidationException(validatoionResult);
            }
            var leaveType = await _leaveTypeRepository.GetLeaveAsync(request.LeaveType.Id);
            _mapper.Map(request.LeaveType,leaveType);
            await _leaveTypeRepository.UpdateLeaveAsync(leaveType);
            return Unit.Value;
        }
    }
}

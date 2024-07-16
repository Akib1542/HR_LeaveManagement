using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveRequest.Validator;
using HR_LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using HR_LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validatoionResult = await validator.ValidateAsync(request.updateLeaveRequestDto);
            if (!validatoionResult.IsValid)
            {
                throw new Exception();
            }

            var updateLeaveRequest = await _leaveRequestRepository.GetAsync(request.Id);
            if (request.updateLeaveRequestDto!=null)
            {
                _mapper.Map(request.updateLeaveRequestDto, updateLeaveRequest);
                await _leaveRequestRepository.UpdateAsync(updateLeaveRequest);
            }
            else if(request.changeLeaveRequestApprovalDto!=null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(updateLeaveRequest,request.changeLeaveRequestApprovalDto.Approved);
            }
            return Unit.Value;
        }
    }
}

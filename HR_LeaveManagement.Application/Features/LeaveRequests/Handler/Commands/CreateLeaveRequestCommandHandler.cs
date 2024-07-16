using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveRequest.Validator;
using HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using HR_LeaveManagement.Application.Persistence.Contracts;
using HR_LeaveManagement.Domain;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestValidator(_leaveTypeRepository);
            var validatoionResult = await validator.ValidateAsync(request.LeaveRequestdto);
            if (!validatoionResult.IsValid)
            {
                throw new Exception();
            }
            var LeaveRequestInDb = _mapper.Map<LeaveRequest>(request.LeaveRequestdto);
            LeaveRequestInDb = await _leaveRequestRepository.AddAsync(LeaveRequestInDb);
            return LeaveRequestInDb.Id;
        }
    }
}

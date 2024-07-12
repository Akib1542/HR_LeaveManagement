using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveType;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR_LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeRequestRequestByIdHandler : IRequestHandler<GetLeaveTypeRequestById, LeaveTypeDto>
    {
     
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeRequestRequestByIdHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeRequestById request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
 }

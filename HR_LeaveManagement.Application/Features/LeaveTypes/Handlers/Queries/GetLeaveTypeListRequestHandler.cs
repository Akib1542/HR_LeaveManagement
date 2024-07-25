using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveType;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }


        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAllLeaveAsync();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}

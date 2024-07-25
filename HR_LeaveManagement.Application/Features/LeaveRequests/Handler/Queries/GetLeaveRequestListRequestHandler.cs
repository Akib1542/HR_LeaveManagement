using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using HR_LeaveManagement.Application.Features.LeaveRequests.Request.Queries;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Handler.Queries
{
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequestListInDb = _leaveRequestRepository.GetAllLeaveRequestAsync();
            if(leaveRequestListInDb == null) 
            {
                return null;
            }
            return _mapper.Map<List<LeaveRequestDto>>(leaveRequestListInDb);
        }
    }
}

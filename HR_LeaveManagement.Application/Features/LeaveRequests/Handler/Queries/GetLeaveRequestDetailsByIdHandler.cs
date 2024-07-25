using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using HR_LeaveManagement.Application.Features.LeaveRequests.Request.Queries;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Handler.Queries
{
    public class GetLeaveRequestDetailsByIdHandler : IRequestHandler<GetLeaveRequestDetailsById, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestDetailsByIdHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }


        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailsById request, CancellationToken cancellationToken)
        {
            var leaveRequestDetails = _leaveRequestRepository.GetLeaveRequestByIdAsync(request.Id);
            if (leaveRequestDetails == null)
            {
                return null;
            }
            return _mapper.Map<LeaveRequestDto>(leaveRequestDetails);
        }
    }
}

using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveAllocation;
using HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var listAllocationInDb = _leaveAllocationRepository.GetAllListAllocationAsync();
            return _mapper.Map<List<LeaveAllocationDto>>(listAllocationInDb);
        }
    }
}

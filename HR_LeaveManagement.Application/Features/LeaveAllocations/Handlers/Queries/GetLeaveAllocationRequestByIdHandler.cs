using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveAllocation;
using HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HR_LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationRequestByIdHandler : IRequestHandler<GetLeaveAllocationRequestById, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationRequestByIdHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationRequestById request, CancellationToken cancellationToken)
        {
            var leaveAllocateInDb = _leaveAllocationRepository.GetListAllocationAsyncById(request.Id);
            if (leaveAllocateInDb == null)
            {
                return null;
            }
            return _mapper.Map<LeaveAllocationDto>(leaveAllocateInDb);
        }
    }
}

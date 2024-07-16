using AutoMapper;
using HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR_LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR_LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    internal class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var dataFromDb = await _leaveAllocationRepository.GetAsync(request.Id);
            await _leaveAllocationRepository.DeleteAsync(dataFromDb);   
            return Unit.Value;
        }
    }
}

using AutoMapper;
using HR_LeaveManagement.Application.Exceptions;
using HR_LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Data.Common;

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
            var dataFromDb = await _leaveAllocationRepository.GetLeaveAsync(request.Id);
            if (dataFromDb == null)
            {
                throw new NotFoundException(nameof(DataAdapter), request.Id);
            }
            await _leaveAllocationRepository.DeleteLeaveAsync(dataFromDb);   
            return Unit.Value;
        }
    }
}

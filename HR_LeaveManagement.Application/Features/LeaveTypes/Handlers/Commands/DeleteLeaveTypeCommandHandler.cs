using HR_LeaveManagement.Application.Exceptions;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Data.Common;

namespace HR_LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var dataFromDb = await _leaveTypeRepository.GetLeaveAsync(request.Id);
            if (dataFromDb == null)
            {
                throw new NotFoundException(nameof(DataAdapter), request.Id);
            }
            await _leaveTypeRepository.DeleteLeaveAsync(dataFromDb);
            return Unit.Value;
        }
    }
}
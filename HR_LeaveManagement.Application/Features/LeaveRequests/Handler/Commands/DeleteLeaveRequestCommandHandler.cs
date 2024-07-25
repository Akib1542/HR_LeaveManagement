using HR_LeaveManagement.Application.Exceptions;
using HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using HR_LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Data.Common;


namespace HR_LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var dataFromDb = await _leaveRequestRepository.GetLeaveAsync(request.Id);
            if(dataFromDb == null)
            {
                throw new NotFoundException(nameof(DataAdapter),request.Id);
            }
            await _leaveRequestRepository.DeleteLeaveAsync(dataFromDb);
            return Unit.Value;
        }
    }
}

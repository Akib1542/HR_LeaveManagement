using HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using HR_LeaveManagement.Application.Persistence.Contracts;
using MediatR;


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
            var dataFromDb = await _leaveRequestRepository.GetAsync(request.Id);
            await _leaveRequestRepository.DeleteAsync(dataFromDb);
            return Unit.Value;
        }
    }
}

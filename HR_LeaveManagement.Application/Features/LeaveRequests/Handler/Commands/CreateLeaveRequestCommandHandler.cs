using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveRequest.Validator;
using HR_LeaveManagement.Application.Features.LeaveRequests.Request.Commands;
using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Application.Responses;
using HR_LeaveManagement.Domain;
using MediatR;
using HR_LeaveManagement.Application.Contracts.Infrastructure;
using HR_LeaveManagement.Application.Models;

namespace HR_LeaveManagement.Application.Features.LeaveRequests.Handler.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponses>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponses> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var validator = new CreateLeaveRequestValidator(_leaveTypeRepository);
            var validatoionResult = await validator.ValidateAsync(request.LeaveRequestdto);
            if (!validatoionResult.IsValid)
            {
               // throw new ValidationException(validatoionResult);
               response.Success = false;
               response.Message = "Creation Failed!";
               response.Errors = validatoionResult.Errors.Select(q=>q.ErrorMessage).ToList();

            }
            var LeaveRequestInDb = _mapper.Map<LeaveRequest>(request.LeaveRequestdto);
            LeaveRequestInDb = await _leaveRequestRepository.AddLeaveAsync(LeaveRequestInDb);

            response.Success = true;
            response.Message = "Creation Successful!";
            response.Id = LeaveRequestInDb.Id;


            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request for {request.LeaveRequestdto.StartDate:D} to {request.LeaveRequestdto.EndDate:D} " +
               $"has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                //// Log or handle error, but don't throw...
            }


            return response;
        }
    }
}

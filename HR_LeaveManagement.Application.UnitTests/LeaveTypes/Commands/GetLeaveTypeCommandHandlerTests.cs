using AutoMapper;
using FluentValidation;
using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Application.DTOs.LeaveType;
using HR_LeaveManagement.Application.Exceptions;
using HR_LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR_LeaveManagement.Application.Profiles;
using HR_LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.ComponentModel.DataAnnotations;

namespace HR_LeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class GetLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;
        public GetLeaveTypeCommandHandlerTests()
        {
            _mockRepo =  MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object,_mapper);
            
            _leaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 10,
                Name = "Test Dto"
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var result = await _handler.Handle(new CreateLeaveTypeCommand { leaveTypeDto = _leaveTypeDto }, CancellationToken.None);
            var leaveTypes = await _mockRepo.Object.GetAllLeaveAsync();
            result.ShouldBeOfType<int>(); 
            leaveTypes.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_LeaveType_Added()
        {
            _leaveTypeDto.DefaultDays = -1;
            ValidationExceptions ex = await Should.ThrowAsync<ValidationExceptions>
                (async () =>
                    await _handler.Handle(new CreateLeaveTypeCommand() { leaveTypeDto = _leaveTypeDto }, CancellationToken.None)
                ) ;
            var leaveTypes = await _mockRepo.Object.GetAllLeaveAsync();
            leaveTypes.Count.ShouldBe(3);   
            ex.ShouldNotBeNull();
        }

    }
}

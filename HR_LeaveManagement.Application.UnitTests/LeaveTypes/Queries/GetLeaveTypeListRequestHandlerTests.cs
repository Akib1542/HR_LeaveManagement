using AutoMapper;
using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Application.DTOs.LeaveType;
using HR_LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR_LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR_LeaveManagement.Application.Profiles;
using HR_LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR_LeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;

        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(c =>
                c.AddProfile<MappingProfile>()
            );

            _mapper = mapperConfig.CreateMapper();  
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);
            result.ShouldBeOfType < List < LeaveTypeDto >> ();
            result.Count.ShouldBe( 3 );
        }
    }
}

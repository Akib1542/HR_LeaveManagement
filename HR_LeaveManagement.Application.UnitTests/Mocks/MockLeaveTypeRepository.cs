using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using Moq;


namespace HR_LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType> 
            { 
               new LeaveType
               {
                   Id = 1,
                   DefaultDays = 10,
                   Name = "Test Vacation"
               },
               new LeaveType
               {
                   Id = 2,
                   DefaultDays = 11,
                   Name = "Test Sick"
               },
               new LeaveType
               {
                   Id = 3,
                   DefaultDays = 15,
                   Name = "Test Maternity"
               }
           };

           var mockRepo = new Mock<ILeaveTypeRepository>();   
           mockRepo.Setup(r => r.GetAllLeaveAsync()).ReturnsAsync(leaveTypes);
           mockRepo.Setup(r => r.AddLeaveAsync(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
           {
               leaveTypes.Add(leaveType);
               return leaveType;
           });
           return mockRepo;
        }
    }
}

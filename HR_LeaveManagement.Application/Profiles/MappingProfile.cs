using AutoMapper;
using HR_LeaveManagement.Application.DTOs.LeaveAllocation;
using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using HR_LeaveManagement.Application.DTOs.LeaveType;
using HR_LeaveManagement.Domain;

namespace HR_LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();  

            CreateMap<LeaveAllocation,LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation,CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType,LeaveTypeDto>().ReverseMap();   
            CreateMap<LeaveType,CreateLeaveTypeDto>().ReverseMap();

        }
    }
}

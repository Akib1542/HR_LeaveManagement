using AutoMapper;
using HR_LeaveManagement.Application.DTOs;
using HR_LeaveManagement.Application.DTOs.LeaveRequest;
using HR_LeaveManagement.Domain;

namespace HR_LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType,LeaveTypeDto>().ReverseMap();   

        }
    }
}

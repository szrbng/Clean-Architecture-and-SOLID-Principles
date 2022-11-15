using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocationsDtos;
using HR.LeaveManagement.Application.DTOs.LeaveRequestDtos;
using HR.LeaveManagement.Application.DTOs.LeaveTypeDtos;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequestt, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestt, LeaveRequestListDto>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.CreatedDate))
                .ReverseMap();
            CreateMap<LeaveRequestt, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequestt, UpdateLeaveRequestDto>().ReverseMap();
           

            CreateMap<LeaveAllocationn, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationn, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationn, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveTypee, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveTypee, CreateLeaveTypeDto>().ReverseMap();
        }
    }
}

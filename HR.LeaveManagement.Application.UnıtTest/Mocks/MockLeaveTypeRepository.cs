﻿using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnıtTest.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveTypee>
            {
                new LeaveTypee
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveTypee
                {
                    Id = 2,
                    DefaultDays = 15,
                    Name = "Test Sick"
                },
                new LeaveTypee
                {
                    Id = 3,
                    DefaultDays = 15,
                    Name = "Test Maternity"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<LeaveTypee>())).ReturnsAsync((LeaveTypee leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepo;

        }
    }
}

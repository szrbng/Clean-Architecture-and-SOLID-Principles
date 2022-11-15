using HR.LeaveManagement.Application.DTOs.LeaveTypeDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.Requests
{
    public class UpdateLeaveTypeRequest : IRequest<Unit>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }

    }
}

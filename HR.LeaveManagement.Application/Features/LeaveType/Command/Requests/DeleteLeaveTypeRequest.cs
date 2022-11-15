using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.Requests
{
    public class DeleteLeaveTypeRequest : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}

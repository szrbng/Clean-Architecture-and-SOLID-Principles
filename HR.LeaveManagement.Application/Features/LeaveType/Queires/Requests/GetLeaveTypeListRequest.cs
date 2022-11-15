using HR.LeaveManagement.Application.DTOs.LeaveTypeDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queires.Requests
{
    public class GetLeaveTypeListRequest: IRequest<List<LeaveTypeDto>>
    {

    }
}

using HR.LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Domain
{
    public class LeaveTypee: BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
       
    }
}

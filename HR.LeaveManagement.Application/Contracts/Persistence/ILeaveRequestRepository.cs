using HR.LeaveManagement.Application.Persistence.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository: IGenericRepository<LeaveRequestt>
    {
        Task<LeaveRequestt> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequestt>> GetLeaveRequestsWithDetails();
        Task<List<LeaveRequestt>> GetLeaveRequestsWithDetails(string userId);
        Task ChangeApprovalStatus(LeaveRequestt leaveRequest, bool? ApprovalStatus);
    }
}

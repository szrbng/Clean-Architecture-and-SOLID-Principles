using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequestt>, ILeaveRequestRepository
    {
        private readonly HrLeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequestt leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        }

        public async Task<List<LeaveRequestt>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequestt>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _dbContext.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leaveRequests;
        }

        public  async Task<LeaveRequestt> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                  .Include(q => q.LeaveType)
                  .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest;
        }
    }
}

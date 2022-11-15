using HR.LeaveManagement.Application.Persistence.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocationn>
    {
        Task<LeaveAllocationn> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocationn>> GetLeaveAllocationsWithDetails();
        Task<List<LeaveAllocationn>> GetLeaveAllocationsWithDetails(string userId);
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocationn> allocations);
        Task<LeaveAllocationn> GetUserAllocations(string userId, int leaveTypeId);
    }
}

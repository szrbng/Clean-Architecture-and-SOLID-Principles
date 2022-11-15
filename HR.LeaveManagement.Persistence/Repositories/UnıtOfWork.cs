using HR.LeaveManagement.Application.Constants;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class UnıtOfWork : IUnitOfWork
    {

        private readonly HrLeaveManagementDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveTypeRepository _leaveTypeRepository;
        private ILeaveRequestRepository _leaveRequestRepository;


        public UnıtOfWork(HrLeaveManagementDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public ILeaveAllocationRepository LeaveAllocationRepository =>
         _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);
        public ILeaveTypeRepository LeaveTypeRepository =>
            _leaveTypeRepository ??= new LeaveTypeRepository(_context);
        public ILeaveRequestRepository LeaveRequestRepository =>
            _leaveRequestRepository ??= new LeaveRequestRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}

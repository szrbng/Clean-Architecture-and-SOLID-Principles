using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.Configurations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.Context
{
    public class HrLeaveManagementDbContext : AuditableDbContext
    {
        public HrLeaveManagementDbContext(DbContextOptions<HrLeaveManagementDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagementDbContext).Assembly);
        }

        public DbSet<LeaveRequestt> LeaveRequests { get; set; }
        public DbSet<LeaveTypee> LeaveTypes { get; set; }
        public DbSet<LeaveAllocationn> LeaveAllocations { get; set; }
    }
}

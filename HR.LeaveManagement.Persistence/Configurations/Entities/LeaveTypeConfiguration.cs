using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveTypee>
    {
        public void Configure(EntityTypeBuilder<LeaveTypee> builder)
        {
            builder.HasData(
              new LeaveTypee
              {
                  Id = 1,
                  DefaultDays = 10,
                  Name = "Vacation",
                  CreatedBy="sezer",
                  LastModifiedBy="sezer"
              },
              new LeaveTypee
              {
                  Id = 2,
                  DefaultDays = 12,
                  Name = "Sick",
                  CreatedBy="sezer",
                  LastModifiedBy="sezer"
              }
          );
        }
    }
}

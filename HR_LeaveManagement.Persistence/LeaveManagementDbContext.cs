using HR_LeaveManagement.Domain;
using HR_LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR_LeaveManagement.Persistence
{
    public class LeaveManagementDbContext:DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        {
        }

        // this method is executed when the database is being generated and we can setup some rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.LastModifiedDate = DateTime.Now;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public LeaveRequest LeaveRequests { get; set; }
        public LeaveAllocation LeaveAllocations { get; set; }
        public LeaveType LeaveTypes { get; set; }

    }
}

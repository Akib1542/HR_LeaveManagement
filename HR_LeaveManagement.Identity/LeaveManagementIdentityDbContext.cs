﻿using HR_LeaveManagement.Identity.Configurations;
using HR_LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR_LeaveManagement.Identity
{
    public class LeaveManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LeaveManagementIdentityDbContext(DbContextOptions<LeaveManagementIdentityDbContext>options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}

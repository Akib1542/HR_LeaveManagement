using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace HR_LeaveManagement.Persistence
{
    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementDbContext>
    {
        /* public LeaveManagementDbContext CreateDbContext(string[] args)
         {
             IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Appsettings.json").Build();
             var builder = new DBNull]
         }*/
        public LeaveManagementDbContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}

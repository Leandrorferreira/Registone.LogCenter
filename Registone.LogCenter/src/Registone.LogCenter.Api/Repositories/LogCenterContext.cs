using Registone.LogCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Registone.LogCenter.Api.Repositories
{
    public class LogCenterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        public LogCenterContext()
        {
        }

        public LogCenterContext(DbContextOptions<LogCenterContext> options): base(options)
        {
        }
    }
}

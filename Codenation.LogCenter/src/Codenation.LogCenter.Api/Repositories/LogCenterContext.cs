using Codenation.LogCenter.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.LogCenter.Api.Repositories
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

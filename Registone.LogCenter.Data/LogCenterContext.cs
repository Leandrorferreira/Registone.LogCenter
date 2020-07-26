using Microsoft.EntityFrameworkCore;
using Registone.LogCenter.Data.Mapping;
using Registone.LogCenter.Domain.Models;

namespace Registone.LogCenter.Data
{
    public class LogCenterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        public LogCenterContext()
        {
        }

        public LogCenterContext(DbContextOptions<LogCenterContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LogMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

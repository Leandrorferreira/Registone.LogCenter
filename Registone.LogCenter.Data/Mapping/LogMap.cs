using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registone.LogCenter.Domain.Models;

namespace Registone.LogCenter.Data.Mapping
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Level).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Title).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Details).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Origin).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.HasOne(x => x.User).WithMany(y => y.Logs).HasForeignKey(x => x.UserId);
            
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

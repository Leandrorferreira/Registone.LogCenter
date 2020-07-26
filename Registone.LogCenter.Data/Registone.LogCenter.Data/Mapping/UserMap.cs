using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registone.LogCenter.Domain.Models;

namespace Registone.LogCenter.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

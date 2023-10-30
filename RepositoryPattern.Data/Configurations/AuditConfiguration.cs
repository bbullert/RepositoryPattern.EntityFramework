using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Configurations
{
    public class AuditConfiguration : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("Audit", "audit");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TableName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.EntityId)
                .IsRequired();

            builder.Property(x => x.ModifiedAt)
                .IsRequired();

            builder.Property(x => x.Values)
                .IsRequired()
                .HasColumnType("nvarchar(max)");
        }
    }
}

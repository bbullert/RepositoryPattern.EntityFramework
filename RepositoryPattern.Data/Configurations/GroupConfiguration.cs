using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Data.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //builder.ToTable("Users", "Accounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.HasMany(x => x.Users)
                .WithMany(x => x.Groups);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "user");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(30);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(30);

            builder.Property(x => x.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.HasMany(x => x.Groups)
                .WithMany(x => x.Users)
                .UsingEntity("GroupUser");

            builder.HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey(x => x.UserId);
        }
    }
}

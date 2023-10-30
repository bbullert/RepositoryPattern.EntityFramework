using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable("Users", "Accounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(x => x.BirthDate)
                .IsRequired();

            //builder.HasMany(x => x.Groups)
            //    .WithMany(x => x.Users)
            //    .UsingEntity(
            //        "GroupUser",
            //        l => l.HasOne(typeof(Group)).WithMany().HasForeignKey("GroupId").HasPrincipalKey(nameof(Group.Id)),
            //        r => r.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
            //        j => j.HasKey("PostsId", "TagsId"));
            //builder.HasMany(x => x.Groups)
            //    .WithMany(x => x.Users)
            //    .UsingEntity(
            //        "GroupUser",
            //        l => l.HasOne(typeof(Group)).WithMany().HasForeignKey("GroupId").HasPrincipalKey(nameof(Group.Id)),
            //        r => r.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
            //        j => j.HasNoKey());
            //builder.HasMany(x => x.Groups)
            //    .WithMany(x => x.Users)
            //    .UsingEntity(
            //        "GroupUser",
            //        l => l.HasOne(typeof(Group)).WithMany().HasForeignKey("GroupId").HasPrincipalKey(nameof(Group.Id)),
            //        r => r.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)));
            //builder.HasMany(x => x.Groups)
            //    .WithMany(x => x.Users)
            //    .UsingEntity(
            //        "GroupUser",
            //        l => l.HasOne(typeof(Group)).WithMany().HasForeignKey("GroupId").HasPrincipalKey(nameof(Group.Id)),
            //        r => r.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)));
            builder.HasMany(x => x.Groups)
                .WithMany(x => x.Users);

            builder.HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey(x => x.UserId);
        }
    }
}

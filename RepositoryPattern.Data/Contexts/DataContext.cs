using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryPattern.Data.Configurations;
using RepositoryPattern.Data.Infrastructure;
using System.Text.Json;

namespace RepositoryPattern.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AuditConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new GroupConfiguration());
        }

        public override int SaveChanges()
        {
            //SaveAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //SaveAudit();
            return base.SaveChangesAsync(cancellationToken);
        }

        //public void SaveAudit()
        //{
        //    var audits = new List<Audit>();
        //    var entries = ChangeTracker.Entries<IAuditable>();

        //    foreach (EntityEntry<IAuditable> entry in entries)
        //    {
        //        var audit = new Audit()
        //        {
        //            TableName = entry.Metadata.GetTableName(),
        //            ModifyDateTime = DateTime.UtcNow
        //        };
        //        Dictionary<string, object> values = new Dictionary<string, object>();

        //        if (entry.State == EntityState.Added)
        //        {
        //            //entityEntry.Entity.CreatedDate = DateTime.UtcNow;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            foreach (var property in entry.Properties)
        //            {
        //                if (property.IsTemporary) continue;

        //                string propertyName = property.Metadata.Name;
        //                values[propertyName] = property.CurrentValue;
        //            }
        //            audit.Values = JsonSerializer.Serialize(values);
        //            audits.Add(audit);
        //        }
        //    }

        //    Audits.AddRange(audits);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=UnitOfWork.BookStore;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}

        //public DbSet<User> Users { get; set; }
        //public DbSet<Audit> Audits { get; set; }
    }
}

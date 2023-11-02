using Microsoft.EntityFrameworkCore.Storage;
using RepositoryPattern.Data.Contexts;

namespace RepositoryPattern.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DataContext Context { get; private set; }
        private IDbContextTransaction Transaction { get; set; }

        public UnitOfWork(DataContext context)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            Transaction = Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (Transaction == null)
                throw new ArgumentNullException(nameof(Transaction));
            Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (Transaction == null)
                throw new ArgumentNullException(nameof(Transaction));
            Transaction.Rollback();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace RepositoryPattern.Data.Infrastructure
{
    public abstract class GenericUnitOfWork<TContext> : 
        IGenericUnitOfWork<TContext>, 
        IDisposable
        where TContext : DbContext
    {
        public TContext Context { get; private set; }
        private IDbContextTransaction Transaction { get; set; }

        public GenericUnitOfWork(TContext context)
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

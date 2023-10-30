using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Data.Infrastructure
{
    public interface IGenericUnitOfWork<TContext> where TContext : DbContext
    {
        TContext Context { get; }

        int Save();
        Task<int> SaveAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Dispose();
    }
}

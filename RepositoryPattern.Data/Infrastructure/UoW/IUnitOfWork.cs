using RepositoryPattern.Data.Contexts;

namespace RepositoryPattern.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        DataContext Context { get; }

        int Save();
        Task<int> SaveAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Dispose();
    }
}

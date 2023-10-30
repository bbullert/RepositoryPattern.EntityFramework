using RepositoryPattern.Data.Infrastructure;
using RepositoryPattern.Data.Repositories;

namespace RepositoryPattern.Data.UoW
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IGroupRepository GroupRepository { get; }
        IItemRepository ItemRepository { get; }
        IUserRepository UserRepository { get; }
        IUserAuditRepository UserAuditRepository { get; }
    }
}
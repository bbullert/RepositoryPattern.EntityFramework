using RepositoryPattern.Data.Contexts;
using RepositoryPattern.Data.Infrastructure;
using RepositoryPattern.Data.Repositories;

namespace RepositoryPattern.Data.UoW
{
    public interface IUserUnitOfWork : IGenericUnitOfWork<ApiContext>
    {
        IGroupRepository GroupRepository { get; }
        IItemRepository ItemRepository { get; }
        IUserRepository UserRepository { get; }
        IUserAuditRepository UserAuditRepository { get; }
    }
}
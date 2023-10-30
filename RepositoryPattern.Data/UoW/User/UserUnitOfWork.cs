using RepositoryPattern.Data.Contexts;
using RepositoryPattern.Data.Infrastructure;
using RepositoryPattern.Data.Repositories;

namespace RepositoryPattern.Data.UoW
{
    public class UserUnitOfWork : UnitOfWork, IUserUnitOfWork
    {
        private IUserRepository _userRepository;
        private IGroupRepository _groupRepository;
        private IItemRepository _itemRepository;
        private IUserAuditRepository _userAuditRepository;

        public UserUnitOfWork(DataContext context) : base(context)
        {
        }

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(Context);
        public IUserAuditRepository UserAuditRepository => _userAuditRepository ?? new UserAuditRepository(Context);
        public IGroupRepository GroupRepository => _groupRepository ?? new GroupRepository(Context);
        public IItemRepository ItemRepository => _itemRepository ?? new ItemRepository(Context);
    }
}

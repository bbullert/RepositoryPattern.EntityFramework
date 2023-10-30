using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Core.Services
{
    public partial class ItemService : IItemService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public ItemService(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }
    }
}

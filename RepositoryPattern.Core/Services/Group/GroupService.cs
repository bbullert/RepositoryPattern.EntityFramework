using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupService : IGroupService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public GroupService(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }
    }
}

using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupUserService : IGroupUserService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public GroupUserService(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }
    }
}

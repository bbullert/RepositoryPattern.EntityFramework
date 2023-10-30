using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService : IUserService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public UserService(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }
    }
}

using RepositoryPattern.Data.Infrastructure;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Data.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}

using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
    }
}

using RepositoryPattern.Data.Contexts;
using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DataContext context) : base(context)
        {
        }
    }
}

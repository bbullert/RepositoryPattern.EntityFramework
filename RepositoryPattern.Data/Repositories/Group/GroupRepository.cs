using RepositoryPattern.Data.Contexts;
using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(DataContext context) : base(context)
        {
        }
    }
}

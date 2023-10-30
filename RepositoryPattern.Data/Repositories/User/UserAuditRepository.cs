using RepositoryPattern.Data.Contexts;
using RepositoryPattern.Data.Infrastructure;
using RepositoryPattern.Data.Infrastructure.Repository;

namespace RepositoryPattern.Data.Repositories
{
    public class UserAuditRepository : GenericAuditRepository<Audit, Guid, Guid>, IUserAuditRepository
    {
        public UserAuditRepository(DataContext context) : base(context, "User")
        {
        }
    }
}

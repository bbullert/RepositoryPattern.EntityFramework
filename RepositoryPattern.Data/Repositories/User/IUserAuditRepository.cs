using RepositoryPattern.Data.Infrastructure;
using RepositoryPattern.Data.Infrastructure.Repository;

namespace RepositoryPattern.Data.Repositories
{
    public interface IUserAuditRepository : IGenericAuditRepository<Audit, Guid, Guid>
    {
    }
}

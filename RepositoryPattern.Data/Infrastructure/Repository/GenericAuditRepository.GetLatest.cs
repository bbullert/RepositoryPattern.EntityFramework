using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual TAudit? GetLatest(TEntityKey entityId)
        {
            return Audits.Select(
                predicate =>
                    predicate.EntityId.Equals(entityId) &&
                    predicate.TableName == TableName,
                null,
                order => order.OrderByDescending(x => x.ModifiedAt),
                selector => selector
            ).FirstOrDefault();
        }

        public virtual Task<TAudit?> GetLatestAsync(TEntityKey entityId)
        {
            return Audits.Select(
                predicate =>
                    predicate.EntityId.Equals(entityId) &&
                    predicate.TableName == TableName,
                null,
                order => order.OrderByDescending(x => x.ModifiedAt),
                selector => selector
            ).FirstOrDefaultAsync();
        }
    }
}

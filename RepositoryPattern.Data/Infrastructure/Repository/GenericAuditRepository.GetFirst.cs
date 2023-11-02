using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual TAudit? GetFirst(TEntityKey entityId)
        {
            return Audits.Select(
                predicate =>
                    predicate.EntityId.Equals(entityId) &&
                    predicate.TableName == TableName,
                null,
                order => order.OrderBy(x => x.ModifiedAt),
                selector => selector
            ).FirstOrDefault();
        }

        public virtual Task<TAudit?> GetFirstAsync(TEntityKey entityId)
        {
            return Audits.Select(
                predicate =>
                    predicate.EntityId.Equals(entityId) &&
                    predicate.TableName == TableName,
                null,
                order => order.OrderBy(x => x.ModifiedAt),
                selector => selector
            ).FirstOrDefaultAsync();
        }
    }
}

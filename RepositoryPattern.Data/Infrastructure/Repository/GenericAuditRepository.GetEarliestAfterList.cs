using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual IEnumerable<TAudit> GetEarliestAfterList(
            TEntityKey entityId,
            DateTime after,
            int? take = default)
        {
            return Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName &&
                predicate.ModifyDateTime >= after,
                order => order.OrderBy(x => x.ModifyDateTime),
                null,
                selector => selector,
                null,
                take).ToList();
        }

        public virtual async Task<IEnumerable<TAudit>> GetEarliestAfterListAsync(
            TEntityKey entityId,
            DateTime after,
            int? take = default)
        {
            return await Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName &&
                predicate.ModifyDateTime >= after,
                order => order.OrderBy(x => x.ModifyDateTime),
                null,
                selector => selector,
                null,
                take).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual IEnumerable<TAudit> GetEarliestList(
            TEntityKey entityId,
            int? take = default)
        {
            return Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName,
                order => order.OrderBy(x => x.ModifyDateTime),
                null,
                order => order.OrderBy(x => x.ModifiedAt),
                selector => selector,
                null,
                take).ToList();
        }

        public virtual async Task<IEnumerable<TAudit>> GetEarliestListAsync(
            TEntityKey entityId,
            int? take = default)
        {
            return await Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName,
                order => order.OrderBy(x => x.ModifyDateTime),
                null,
                order => order.OrderBy(x => x.ModifiedAt),
                selector => selector,
                null,
                take).ToListAsync();
        }
    }
}

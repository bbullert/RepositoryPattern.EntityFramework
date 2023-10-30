using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual IEnumerable<TAudit> GetBetweenList(
            TEntityKey entityId,
            DateTime from,
            DateTime to)
        {
            return Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName &&
                predicate.ModifiedAt >= from &&
                predicate.ModifiedAt <= to,
                null,
                order => order.OrderByDescending(x => x.ModifiedAt),
                selector => selector).ToList();
        }

        public virtual async Task<IEnumerable<TAudit>> GetBetweenListAsync(
            TEntityKey entityId,
            DateTime from,
            DateTime to)
        {
            return await Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName &&
                predicate.ModifiedAt >= from &&
                predicate.ModifiedAt <= to,
                null,
                order => order.OrderByDescending(x => x.ModifiedAt),
                selector => selector).ToListAsync();
        }
    }
}

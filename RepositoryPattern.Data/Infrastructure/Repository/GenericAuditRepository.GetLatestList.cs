using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual IEnumerable<TAudit> GetLatestList(
            TEntityKey entityId,
            int? take = default)
        {
            return Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName, 
                null, 
                order => order.OrderByDescending(x => x.ModifiedAt), 
                selector => selector, 
                null, 
                take).ToList();
        }

        public virtual async Task<IEnumerable<TAudit>> GetLatestListAsync(
            TEntityKey entityId,
            int? take = default)
        {
            return await Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName,
                null,
                order => order.OrderByDescending(x => x.ModifiedAt),
                selector => selector,
                null,
                take).ToListAsync();
        }
    }
}

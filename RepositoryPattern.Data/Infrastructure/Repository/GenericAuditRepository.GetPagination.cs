using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual IPagination<TAudit> GetPagination(
            TEntityKey entityId,
            IAuditCriteria criteria)
        {
            return Audits.Select(
                predicate =>
                    predicate.EntityId.Equals(entityId) &&
                    predicate.TableName == TableName &&
                    (criteria.ModifiedAtFrom == null || predicate.ModifiedAt >= criteria.ModifiedAtFrom) &&
                    (criteria.ModifiedAtTo == null || predicate.ModifiedAt <= criteria.ModifiedAtTo),
                null,
                order => criteria.OrderByLatest ?
                    order.OrderByDescending(x => x.ModifiedAt) :
                    order.OrderBy(x => x.ModifiedAt),
                selector => selector
            ).ToPagination(criteria.Index ?? 1, criteria.Size ?? 30);
        }

        public virtual Task<IPagination<TAudit>> GetPaginationAsync(
            TEntityKey entityId,
            IAuditCriteria criteria)
        {
            return Audits.Select(
                predicate =>
                    predicate.EntityId.Equals(entityId) &&
                    predicate.TableName == TableName &&
                    (criteria.ModifiedAtFrom == null || predicate.ModifiedAt >= criteria.ModifiedAtFrom) &&
                    (criteria.ModifiedAtTo == null || predicate.ModifiedAt <= criteria.ModifiedAtTo),
                null,
                order => criteria.OrderByLatest ?
                    order.OrderByDescending(x => x.ModifiedAt) :
                    order.OrderBy(x => x.ModifiedAt),
                selector => selector
            ).ToPaginationAsync(criteria.Index ?? 1, criteria.Size ?? 30);
        }
    }
}

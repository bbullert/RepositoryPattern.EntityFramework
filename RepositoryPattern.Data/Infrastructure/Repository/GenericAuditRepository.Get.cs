using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual TAudit? Get(TAuditKey auditId)
        {
            return Audits.Select(
                predicate => predicate.Id.Equals(auditId),
                null, null,
                selector => selector
            ).FirstOrDefault();
        }

        public virtual Task<TAudit?> GetAsync(TAuditKey auditId)
        {
            return Audits.Select(
                predicate => predicate.Id.Equals(auditId),
                null, null,
                selector => selector
            ).FirstOrDefaultAsync();
        }
    }
}

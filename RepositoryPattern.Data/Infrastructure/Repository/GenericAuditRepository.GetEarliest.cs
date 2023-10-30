﻿using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual TAudit? GetEarliest(
            TEntityKey entityId,
            int? take = default)
        {
            return Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName,
                order => order.OrderBy(x => x.ModifyDateTime),
                null,
                selector => selector).FirstOrDefault();
        }

        public virtual async Task<TAudit?> GetEarliestAsync(
            TEntityKey entityId,
            int? take = default)
        {
            return await Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName,
                order => order.OrderBy(x => x.ModifyDateTime),
                null,
                selector => selector).FirstOrDefaultAsync();
        }
    }
}

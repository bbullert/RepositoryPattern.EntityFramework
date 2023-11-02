﻿using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Extensions;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey>
    {
        public virtual TAudit? GetLatest(
            TEntityKey entityId,
            int? take = default)
        {
            return Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName,
                null,
                order => order.OrderByDescending(x => x.ModifiedAt),
                selector => selector).FirstOrDefault();
        }

        public virtual async Task<TAudit?> GetLatestAsync(
            TEntityKey entityId,
            int? take = default)
        {
            return await Audits.Select(
                predicate =>
                predicate.EntityId.Equals(entityId) &&
                predicate.TableName == TableName,
                null,
                order => order.OrderByDescending(x => x.ModifiedAt),
                selector => selector).FirstOrDefaultAsync();
        }
    }
}
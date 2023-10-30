using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public partial class GenericAuditRepository<TAudit, TAuditKey, TEntityKey> : 
        IGenericAuditRepository<TAudit, TAuditKey, TEntityKey> 
        where TAudit : class, IGenericAudit<TAuditKey, TEntityKey>
        where TAuditKey : IEquatable<TAuditKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TAudit> Audits;
        protected readonly string TableName;

        public GenericAuditRepository(DbContext context, string tableName)
        {
            Context = context ?? throw new ArgumentException(nameof(context));
            Audits = context.Set<TAudit>();
            TableName = tableName;
        }
    }
}

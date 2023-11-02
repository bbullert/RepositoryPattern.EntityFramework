namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public interface IGenericAuditRepository<TAudit, TAuditKey, TEntityKey>
        where TAudit : class, IGenericAudit<TAuditKey, TEntityKey>
        where TAuditKey : IEquatable<TAuditKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        TAudit? Get(TAuditKey auditId);
        Task<TAudit?> GetAsync(TAuditKey auditId);
        TAudit? GetFirst(TEntityKey entityId);
        Task<TAudit?> GetFirstAsync(TEntityKey entityId);
        TAudit? GetLatest(TEntityKey entityId);
        Task<TAudit?> GetLatestAsync(TEntityKey entityId);
        IPagination<TAudit> GetPagination(TEntityKey entityId, IAuditCriteria criteria);
        Task<IPagination<TAudit>> GetPaginationAsync(TEntityKey entityId, IAuditCriteria criteria);
    }
}
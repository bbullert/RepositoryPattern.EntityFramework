namespace RepositoryPattern.Data.Infrastructure.Repository
{
    public interface IGenericAuditRepository<TAudit, TAuditKey, TEntityKey>
        where TAudit : class, IGenericAudit<TAuditKey, TEntityKey>
        where TAuditKey : IEquatable<TAuditKey>
        where TEntityKey : IEquatable<TEntityKey>
    {
        IEnumerable<TAudit> GetBetweenList(TEntityKey entityId, DateTime from, DateTime to);
        Task<IEnumerable<TAudit>> GetBetweenListAsync(TEntityKey entityId, DateTime from, DateTime to);
        TAudit? GetEarliest(TEntityKey entityId, int? take = null);
        IEnumerable<TAudit> GetEarliestAfterList(TEntityKey entityId, DateTime after, int? take = null);
        Task<IEnumerable<TAudit>> GetEarliestAfterListAsync(TEntityKey entityId, DateTime after, int? take = null);
        Task<TAudit?> GetEarliestAsync(TEntityKey entityId, int? take = null);
        IEnumerable<TAudit> GetEarliestList(TEntityKey entityId, int? take = null);
        Task<IEnumerable<TAudit>> GetEarliestListAsync(TEntityKey entityId, int? take = null);
        TAudit? GetLatest(TEntityKey entityId, int? take = null);
        Task<TAudit?> GetLatestAsync(TEntityKey entityId, int? take = null);
        IEnumerable<TAudit> GetLatestBeforeList(TEntityKey entityId, DateTime before, int? take = null);
        Task<IEnumerable<TAudit>> GetLatestBeforeListAsync(TEntityKey entityId, DateTime before, int? take = null);
        IEnumerable<TAudit> GetLatestList(TEntityKey entityId, int? take = null);
        Task<IEnumerable<TAudit>> GetLatestListAsync(TEntityKey entityId, int? take = null);
    }
}
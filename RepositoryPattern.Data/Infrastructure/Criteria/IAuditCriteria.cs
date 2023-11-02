namespace RepositoryPattern.Data.Infrastructure
{
    public interface IAuditCriteria
    {
        int? Index { get; set; }
        DateTime? ModifiedAtFrom { get; set; }
        DateTime? ModifiedAtTo { get; set; }
        bool OrderByLatest { get; set; }
        int? Size { get; set; }
    }
}
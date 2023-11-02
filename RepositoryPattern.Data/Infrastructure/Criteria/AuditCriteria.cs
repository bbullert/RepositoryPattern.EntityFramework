namespace RepositoryPattern.Data.Infrastructure
{
    public class AuditCriteria : IAuditCriteria
    {
        public int? Index { get; set; }
        public int? Size { get; set; }
        public bool OrderByLatest { get; set; }
        public DateTime? ModifiedAtFrom { get; set; }
        public DateTime? ModifiedAtTo { get; set; }
    }
}

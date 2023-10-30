namespace RepositoryPattern.Data.Infrastructure
{
    public class Criteria : ICriteria
    {
        public int? Index { get; set; }
        public int? Size { get; set; }
        public string? OrderBy { get; set; }
    }
}

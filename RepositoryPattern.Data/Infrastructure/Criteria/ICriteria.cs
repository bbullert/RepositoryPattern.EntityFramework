namespace RepositoryPattern.Data.Infrastructure
{
    public interface ICriteria
    {
        int? Index { get; set; }
        string? OrderBy { get; set; }
        int? Size { get; set; }
    }
}
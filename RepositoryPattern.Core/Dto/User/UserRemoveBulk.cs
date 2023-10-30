namespace RepositoryPattern.Core.Dto
{
    public class UserRemoveBulk
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}

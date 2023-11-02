namespace RepositoryPattern.Core.Dto
{
    public class UserBulkRemove
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}

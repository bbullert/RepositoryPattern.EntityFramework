namespace RepositoryPattern.Core.Dto
{
    public class UserBulkUpdate
    {
        public IEnumerable<UserBulkUpdateItem> Users { get; set; }
    }
}

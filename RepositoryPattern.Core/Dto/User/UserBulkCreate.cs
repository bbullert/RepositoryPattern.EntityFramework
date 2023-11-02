namespace RepositoryPattern.Core.Dto
{
    public class UserBulkCreate
    {
        public IEnumerable<UserBulkCreateItem> Users { get; set; }
    }
}

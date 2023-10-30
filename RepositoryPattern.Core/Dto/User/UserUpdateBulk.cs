namespace RepositoryPattern.Core.Dto
{
    public class UserUpdateBulk
    {
        public IEnumerable<UserUpdate> Users { get; set; }
    }
}

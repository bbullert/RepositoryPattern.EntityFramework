namespace RepositoryPattern.Core.Dto
{
    public class UserCreateBulk
    {
        public IEnumerable<UserCreate> Users { get; set; }
    }
}

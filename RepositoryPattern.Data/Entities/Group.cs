using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Entities
{
    public class Group : Entity<Guid>
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}

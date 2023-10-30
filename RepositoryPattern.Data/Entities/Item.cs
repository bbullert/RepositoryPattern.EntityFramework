using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Entities
{
    public class Item : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}

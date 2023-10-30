using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Data.Entities
{
    public class User : Entity<Guid>, IAuditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}

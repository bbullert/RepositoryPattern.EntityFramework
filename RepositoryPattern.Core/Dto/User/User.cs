namespace RepositoryPattern.Core.Dto
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public static User FromEntity(Data.Entities.User entity)
        {
            return new User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
                Items = entity.Items?.Select(x => Item.FromEntity(x))
            };
        }
    }
}

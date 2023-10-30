namespace RepositoryPattern.Core.Dto
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }

        public static Group FromEntity(Data.Entities.Group entity)
        {
            return new Group()
            {
                Id = entity.Id,
                Name = entity.Name,
                Users = entity.Users?.Select(x => User.FromEntity(x))
            };
        }
    }
}

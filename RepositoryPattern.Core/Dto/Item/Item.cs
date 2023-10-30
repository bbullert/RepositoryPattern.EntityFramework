namespace RepositoryPattern.Core.Dto
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public static Item FromEntity(Data.Entities.Item entity)
        {
            return new Item()
            {
                Id = entity.Id,
                Name = entity.Name,
                UserId = entity.UserId
            };
        }
    }
}

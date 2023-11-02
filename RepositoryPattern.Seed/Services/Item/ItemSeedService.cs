using Bogus;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public class ItemSeedService : IItemSeedService
    {
        public Faker<Item> SeedGenerator()
        {
            Random random = new Random();
            var generator = new Faker<Item>()
                .RuleFor(o => o.Name, (f, u) =>
                    "Item#" + random.Next(1, 99999).ToString().PadLeft(5, '0')
                );
            return generator;
        }
    }
}

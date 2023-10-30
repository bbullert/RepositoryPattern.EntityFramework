using Bogus;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Generators
{
    public class ItemGenerator
    {
        public Faker<Item> GetGenerator()
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

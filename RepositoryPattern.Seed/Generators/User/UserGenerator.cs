using Bogus;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Generators
{
    public class UserGenerator
    {
        public Faker<User> GetGenerator(Faker<Item> itemGenerator)
        {
            Random random = new Random();
            var generator = new Faker<User>()
                .RuleFor(o => o.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(o => o.LastName, (f, u) => f.Name.LastName())
                .RuleFor(o => o.BirthDate, (f, u) =>
                    f.Date.BetweenDateOnly(new DateOnly(1920, 1, 1), new DateOnly(2005, 1, 1)).ToDateTime(TimeOnly.MinValue)
                )
                .RuleFor(o => o.Items, (f, u) =>
                    itemGenerator.Generate(random.Next(1, 3)).ToList()
                );
            return generator;
        }
    }
}

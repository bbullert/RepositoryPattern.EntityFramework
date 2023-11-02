using Bogus;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public interface IUserSeedService
    {
        Faker<User> SeedGenerator(Faker<Item> itemGenerator);
    }
}
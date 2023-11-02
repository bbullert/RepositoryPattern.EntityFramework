using Bogus;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public interface IItemSeedService
    {
        Faker<Item> SeedGenerator();
    }
}
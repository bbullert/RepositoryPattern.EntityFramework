using Bogus;
using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public interface IGroupSeedService
    {
        Faker<Group> SeedGenerator(Faker<User> userGenerator);
    }
}
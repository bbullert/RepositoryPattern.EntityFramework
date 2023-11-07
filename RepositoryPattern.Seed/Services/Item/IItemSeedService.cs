using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public interface IItemSeedService
    {
        Task<IEnumerable<Item>> EnsureItemsAsync(IEnumerable<User> users);
    }
}
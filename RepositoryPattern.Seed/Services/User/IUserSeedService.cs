using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public interface IUserSeedService
    {
        Task<IEnumerable<User>> EnsureUsersAsync(IEnumerable<Group> groups);
    }
}
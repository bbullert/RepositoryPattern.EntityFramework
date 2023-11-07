using RepositoryPattern.Data.Entities;

namespace RepositoryPattern.Seed.Services
{
    public interface IGroupSeedService
    {
        Task<IEnumerable<Group>> EnsureGroupsAsync();
    }
}
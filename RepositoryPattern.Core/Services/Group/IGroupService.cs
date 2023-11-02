using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Core.Services
{
    public interface IGroupService
    {
        Task<Guid> CreateAsync(GroupCreate create);
        Task<Group> GetAsync(Guid id);
        Task<IEnumerable<Group>> GetListAsync();
        Task PutAsync(Guid id, GroupUpdate update);
        Task RemoveAsync(Guid id);
    }
}
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Core.Services
{
    public interface IGroupUserService
    {
        Task AddUserToGroupAsync(Guid groupId, Guid userId);
        Task<IEnumerable<User>> GetGroupUsersAsync(Guid groupId);
        Task<IEnumerable<Group>> GetUserGroupsAsync(Guid userId);
        Task RemoveUserFromGroupAsync(Guid groupId, Guid userId);
    }
}
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupUserService
    {
        public async Task<IEnumerable<Group>> GetUserGroupsAsync(Guid userId)
        {
            bool userExists = await _userUnitOfWork.UserRepository.ExistsAsync(x => x.Id == userId);
            if (!userExists)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var groups = await _userUnitOfWork.GroupRepository.GetListAsync(
                x => x.Users.Select(x => x.Id).Contains(userId));

            var groupDtos = groups.Select(x => Group.FromEntity(x)).ToList();
            return groupDtos;
        }
    }
}

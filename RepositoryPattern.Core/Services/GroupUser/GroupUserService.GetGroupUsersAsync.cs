using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupUserService
    {
        public async Task<IEnumerable<User>> GetGroupUsersAsync(Guid groupId)
        {
            var group = await _userUnitOfWork.GroupRepository.GetAsync(
                x => x.Id == groupId, null, 
                include => include.Include(x => x.Users));
            if (group == null)
                throw new HttpRequestException("Group not found.", null, HttpStatusCode.NotFound);
            
            var userDtos = group.Users.Select(x => User.FromEntity(x)).ToList();
            return userDtos;
        }
    }
}

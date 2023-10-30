using Microsoft.EntityFrameworkCore;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupUserService
    {
        public async Task AddUserToGroupAsync(Guid groupId, Guid userId)
        {
            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == userId);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var group = await _userUnitOfWork.GroupRepository.GetAsync(
                x => x.Id == groupId, 
                include => include.Include(x => x.Users),
                null, false);
            if (group == null)
                throw new HttpRequestException("Group not found.", null, HttpStatusCode.NotFound);

            if (group.Users.Any(x => x.Id == user.Id))
                throw new HttpRequestException("User is already a member of the group.", null, HttpStatusCode.Conflict);

            var updated = group.Users.ToList();
            updated.Add(user);
            group.Users = updated;
            _userUnitOfWork.GroupRepository.Update(group);

            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");
        }
    }
}

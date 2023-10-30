using Microsoft.EntityFrameworkCore;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupUserService
    {
        public async Task RemoveUserFromGroupAsync(Guid groupId, Guid userId)
        {
            var group = await _userUnitOfWork.GroupRepository.GetAsync(
                x => x.Id == groupId, 
                include => include.Include(x => x.Users),
                null, false);
            if (group == null)
                throw new HttpRequestException("Group not found.", null, HttpStatusCode.NotFound);
            
            var user = group.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
                throw new HttpRequestException("User is not a member of the group.", null, HttpStatusCode.NotFound);

            var updated = group.Users.ToList();
            updated.Remove(user);
            group.Users = updated;
            _userUnitOfWork.GroupRepository.Update(group);

            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
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

            bool userExists = await _userUnitOfWork.UserRepository.ExistsAsync(x => x.Id == userId);
            if (!userExists)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var user = group.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
                throw new HttpRequestException("User is not a member of the group.", null, HttpStatusCode.NotFound);

            var updated = group.Users.ToList();
            updated.Remove(user);
            group.Users = updated;
            _userUnitOfWork.GroupRepository.Update(group);

            await _userUnitOfWork.SaveAsync();
        }
    }
}

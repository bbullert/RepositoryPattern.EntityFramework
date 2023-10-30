using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupService
    {
        public async Task PutAsync(Guid id, GroupCreate update)
        {
            var group = await _userUnitOfWork.GroupRepository.GetAsync(x => x.Id == id);
            if (group == null)
                throw new HttpRequestException("Group not found.", null, HttpStatusCode.NotFound);

            var updated = update.ToEntity();
            updated.Id = id;
            _userUnitOfWork.GroupRepository.Update(updated);

            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");
        }
    }
}

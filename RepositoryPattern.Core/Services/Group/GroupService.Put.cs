using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupService
    {
        public async Task PutAsync(Guid id, GroupUpdate update)
        {
            var group = await _userUnitOfWork.GroupRepository.GetAsync(x => x.Id == id);
            if (group == null)
                throw new HttpRequestException("Group not found.", null, HttpStatusCode.NotFound);

            update.UpdateEntity(group);
            _userUnitOfWork.GroupRepository.Update(group);

            await _userUnitOfWork.SaveAsync();
        }
    }
}

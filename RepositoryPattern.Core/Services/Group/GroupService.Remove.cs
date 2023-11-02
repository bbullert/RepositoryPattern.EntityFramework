using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupService
    {
        public async Task RemoveAsync(Guid id)
        {
            var group = await _userUnitOfWork.GroupRepository.GetAsync(x => x.Id == id);
            if (group == null)
                throw new HttpRequestException("Group not found.", null, HttpStatusCode.NotFound);

            _userUnitOfWork.GroupRepository.Remove(group);

            await _userUnitOfWork.SaveAsync();
        }
    }
}

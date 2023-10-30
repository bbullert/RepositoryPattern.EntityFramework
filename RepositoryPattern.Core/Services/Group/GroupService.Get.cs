using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupService
    {
        public async Task<Group> GetAsync(Guid id)
        {
            var group = await _userUnitOfWork.GroupRepository.GetAsync(x => x.Id == id);
            if (group == null)
                throw new HttpRequestException("Group not found.", null, HttpStatusCode.NotFound);

            var groupDto = Group.FromEntity(group);
            return groupDto;
        }

        public async Task<IEnumerable<Group>> GetListAsync()
        {
            var groups = await _userUnitOfWork.GroupRepository.GetListAsync();
            var groupDtos = groups.Select(x => Group.FromEntity(x)).ToList();
            return groupDtos;
        }
    }
}

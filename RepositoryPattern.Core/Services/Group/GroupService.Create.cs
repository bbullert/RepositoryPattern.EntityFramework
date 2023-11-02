using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupService
    {
        public async Task<Guid> CreateAsync(GroupCreate create)
        {
            var id = await _userUnitOfWork.GroupRepository.AddAsync(x => x.Id, create.ToEntity());
            
            await _userUnitOfWork.SaveAsync();
            return id;
        }
    }
}

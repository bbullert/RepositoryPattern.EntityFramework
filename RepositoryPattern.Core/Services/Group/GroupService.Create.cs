using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Core.Services
{
    public partial class GroupService
    {
        public async Task<Guid> CreateAsync(GroupCreate create)
        {
            var id = await _userUnitOfWork.GroupRepository.AddAsync(x => x.Id, create.ToEntity());
            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");

            return id;
        }
    }
}

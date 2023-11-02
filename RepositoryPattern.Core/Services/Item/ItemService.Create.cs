using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class ItemService
    {
        public async Task<Guid> CreateAsync(ItemCreate create)
        {
            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == create.UserId);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var id = await _userUnitOfWork.ItemRepository.AddAsync(x => x.Id, create.ToEntity());

            await _userUnitOfWork.SaveAsync();
            return id;
        }
    }
}

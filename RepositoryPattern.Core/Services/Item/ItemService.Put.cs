using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class ItemService
    {
        public async Task PutAsync(Guid id, ItemCreate update)
        {
            var item = await _userUnitOfWork.ItemRepository.GetAsync(x => x.Id == id);
            if (item == null)
                throw new HttpRequestException("Item not found.", null, HttpStatusCode.NotFound);

            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == update.UserId);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var updated = update.ToEntity();
            updated.Id = id;
            _userUnitOfWork.ItemRepository.Update(updated);

            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");
        }
    }
}

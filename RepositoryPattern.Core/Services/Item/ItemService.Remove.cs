using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class ItemService
    {
        public async Task RemoveAsync(Guid id)
        {
            var item = await _userUnitOfWork.ItemRepository.GetAsync(x => x.Id == id);
            if (item == null)
                throw new HttpRequestException("Item not found.", null, HttpStatusCode.NotFound);

            _userUnitOfWork.ItemRepository.Remove(item);

            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");
        }
    }
}

using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class ItemService
    {
        public async Task<Item> GetAsync(Guid id)
        {
            var item = await _userUnitOfWork.ItemRepository.GetAsync(x => x.Id == id);
            if (item == null)
                throw new HttpRequestException("Item not found.", null, HttpStatusCode.NotFound);

            var itemDto = Item.FromEntity(item);
            return itemDto;
        }

        public async Task<IEnumerable<Item>> GetListAsync()
        {
            var items = await _userUnitOfWork.ItemRepository.GetListAsync();
            var itemDtos = items.Select(x => Item.FromEntity(x)).ToList();
            return itemDtos;
        }
    }
}

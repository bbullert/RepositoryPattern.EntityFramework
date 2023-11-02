using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Core.Services
{
    public interface IItemService
    {
        Task<Guid> CreateAsync(ItemCreate create);
        Task<Item> GetAsync(Guid id);
        Task<IEnumerable<Item>> GetListAsync();
        Task PutAsync(Guid id, ItemUpdate update);
        Task RemoveAsync(Guid id);
    }
}
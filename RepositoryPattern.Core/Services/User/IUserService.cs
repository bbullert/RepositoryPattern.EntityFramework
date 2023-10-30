using Microsoft.AspNetCore.JsonPatch;
using RepositoryPattern.Core.Dto;
using RepositoryPattern.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Services
{
    public interface IUserService
    {
        Task<Guid> CreateAsync(UserCreate user);
        Task<IEnumerable<Guid>> CreateBulkAsync(IEnumerable<UserCreate> users);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetListAsync();
        Task<IPagination<User>> GetPaginationAsync(UserCriteria criteria);
        Task<IEnumerable<ValidationResult>> PatchAsync(Guid id, JsonPatchDocument<UserCreate> patch);
        UserUpdateBulk PatchBulkMockData();
        Task PutAsync(Guid id, UserCreate update);
        Task PutBulkAsync(IEnumerable<UserUpdate> updates);
        Task RemoveAsync(Guid id);
        Task RemoveBulkAsync(IEnumerable<Guid> ids);
    }
}
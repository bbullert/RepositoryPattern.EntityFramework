using Microsoft.AspNetCore.JsonPatch;
using RepositoryPattern.Core.Dto;
using RepositoryPattern.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task<IEnumerable<ValidationResult>> PatchAsync(Guid id, JsonPatchDocument<UserCreate> patch)
        {
            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == id);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var updated = UserCreate.FromEntity(user);
            patch.ApplyTo(updated);

            var validationResults = DataAnnotationsExtensions.Validate(updated);
            if (validationResults.Any())
                return validationResults;

            user = updated.ToEntity();
            user.Id = id;
            _userUnitOfWork.UserRepository.Update(user);

            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");

            return validationResults;
        }

        public UserUpdateBulk PatchBulkMockData()
        {
            var users = new List<UserUpdate>()
            {
                new UserUpdate()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Test",
                    LastName = "Test",
                    BirthDate = DateTime.UtcNow,
                },
                new UserUpdate()
                {
                    Id = new Guid("68778B28-2E89-493E-8815-08DBD24969DF"),
                    FirstName = "Test",
                    LastName = "Test",
                    BirthDate = DateTime.UtcNow,
                },
                new UserUpdate()
                {
                    Id = new Guid("01F81940-29E5-48B2-8814-08DBD24969DF"),
                    FirstName = "Test2",
                    LastName = "Test2",
                    BirthDate = DateTime.UtcNow,
                }
            };
            return new UserUpdateBulk() { Users = users };
        }
    }
}

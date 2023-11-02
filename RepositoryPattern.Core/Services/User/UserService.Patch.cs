using Microsoft.AspNetCore.JsonPatch;
using RepositoryPattern.Core.Dto;
using RepositoryPattern.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task<IEnumerable<ValidationResult>> PatchAsync(Guid id, JsonPatchDocument<UserUpdate> patch)
        {
            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == id);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var updated = UserUpdate.FromEntity(user);
            patch.ApplyTo(updated);

            var validationResults = DataAnnotationsExtensions.Validate(updated);
            if (validationResults.Any())
                return validationResults;

            updated.UpdateEntity(user);
            _userUnitOfWork.UserRepository.Update(user);

            await _userUnitOfWork.SaveAsync();
            return validationResults;
        }
    }
}

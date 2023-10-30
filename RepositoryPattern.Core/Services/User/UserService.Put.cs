using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task PutAsync(Guid id, UserCreate update)
        {
            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == id);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var updated = update.ToEntity();
            updated.Id = id;
            _userUnitOfWork.UserRepository.Update(updated);

            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");
        }

        public async Task PutBulkAsync(IEnumerable<UserUpdate> updates)
        {
            _userUnitOfWork.BeginTransaction();
            try
            {
                var users = await _userUnitOfWork.UserRepository.GetListAsync(
                    predicate => updates.Select(x => x.Id).Contains(predicate.Id));

                var range = new List<Data.Entities.User>();
                foreach (var update in updates)
                {
                    var user = users.FirstOrDefault(x => x.Id == update.Id);
                    if (user == null)
                        throw new HttpRequestException($"User ({update.Id}) not found.", null, HttpStatusCode.NotFound);

                    var updated = update.ToEntity();
                    updated.Id = user.Id;
                    range.Add(updated);
                }

                _userUnitOfWork.UserRepository.UpdateRange(range);
                var savedCount = await _userUnitOfWork.SaveAsync();
                if (savedCount != updates.Count())
                    throw new ApplicationException("Unable to save changes.");

                _userUnitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                _userUnitOfWork.RollbackTransaction();
                _userUnitOfWork.Dispose();
                throw;
            }
        }
    }
}

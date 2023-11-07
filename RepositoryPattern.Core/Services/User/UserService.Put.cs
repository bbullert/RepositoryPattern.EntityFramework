using RepositoryPattern.Core.Dto;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task PutAsync(Guid id, UserUpdate update)
        {
            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == id);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            update.UpdateEntity(user);
            _userUnitOfWork.UserRepository.Update(user);

            await _userUnitOfWork.SaveAsync();
        }

        public async Task PutBulkAsync(IEnumerable<UserBulkUpdateItem> updates)
        {
            try
            {
                _userUnitOfWork.BeginTransaction();

                var users = await _userUnitOfWork.UserRepository.GetListAsync(
                    predicate => updates.Select(x => x.Id).Contains(predicate.Id));

                var range = new List<Data.Entities.User>();
                foreach (var update in updates)
                {
                    var user = users.FirstOrDefault(x => x.Id == update.Id);
                    if (user == null)
                        throw new HttpRequestException($"User ({update.Id}) not found.", null, HttpStatusCode.NotFound);

                    update.UpdateEntity(user);
                    range.Add(user);
                }
                _userUnitOfWork.UserRepository.UpdateRange(range);

                await _userUnitOfWork.SaveAsync();
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

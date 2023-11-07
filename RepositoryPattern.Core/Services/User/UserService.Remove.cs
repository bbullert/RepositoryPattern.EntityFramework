using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task RemoveAsync(Guid id)
        {
            var user = await _userUnitOfWork.UserRepository.GetAsync(x => x.Id == id);
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            _userUnitOfWork.UserRepository.Remove(user);

            await _userUnitOfWork.SaveAsync();
        }

        public async Task RemoveBulkAsync(IEnumerable<Guid> ids)
        {
            try
            {
                _userUnitOfWork.BeginTransaction();

                var users = await _userUnitOfWork.UserRepository.GetListAsync(
                    predicate => ids.Contains(predicate.Id));

                var range = new List<Data.Entities.User>();
                foreach (var id in ids)
                {
                    var user = users.FirstOrDefault(x => x.Id == id);
                    if (user == null)
                        throw new HttpRequestException($"User ({id}) not found.", null, HttpStatusCode.NotFound);

                    range.Add(user);
                }
                _userUnitOfWork.UserRepository.RemoveRange(range);

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

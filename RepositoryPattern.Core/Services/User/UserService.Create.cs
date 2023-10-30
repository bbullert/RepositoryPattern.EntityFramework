using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task<Guid> CreateAsync(UserCreate user)
        {
            var id = await _userUnitOfWork.UserRepository.AddAsync(x => x.Id, user.ToEntity());
            var savedCount = await _userUnitOfWork.SaveAsync();
            if (savedCount == 0)
                throw new ApplicationException("Unable to save changes.");

            return id;
        }

        public async Task<IEnumerable<Guid>> CreateBulkAsync(IEnumerable<UserCreate> users)
        {
            _userUnitOfWork.BeginTransaction();
            try
            {
                var ids = await _userUnitOfWork.UserRepository.AddRangeAsync(
                    x => x.Id, users.Select(x => x.ToEntity()));

                var savedCount = await _userUnitOfWork.SaveAsync();
                if (savedCount != users.Count())
                    throw new ApplicationException("Unable to save changes.");

                _userUnitOfWork.CommitTransaction();

                return ids;
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

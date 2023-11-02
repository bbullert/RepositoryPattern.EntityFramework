using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task<Guid> CreateAsync(UserCreate user)
        {
            var id = await _userUnitOfWork.UserRepository.AddAsync(x => x.Id, user.ToEntity());
            
            await _userUnitOfWork.SaveAsync();
            return id;
        }

        public async Task<IEnumerable<Guid>> CreateBulkAsync(IEnumerable<UserBulkCreateItem> users)
        {
            _userUnitOfWork.BeginTransaction();
            try
            {
                var ids = await _userUnitOfWork.UserRepository.AddRangeAsync(
                    x => x.Id, users.Select(x => x.ToEntity()));

                await _userUnitOfWork.SaveAsync();
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

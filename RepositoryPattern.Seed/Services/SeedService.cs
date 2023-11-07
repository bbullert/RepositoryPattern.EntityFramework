using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Seed.Services
{
    public class SeedService : ISeedService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IUserSeedService _userSeedService;
        private readonly IGroupSeedService _groupSeedService;
        private readonly IItemSeedService _itemSeedService;

        public SeedService(
            IUserUnitOfWork userUnitOfWork,
            IUserSeedService userSeedService,
            IGroupSeedService groupSeedService,
            IItemSeedService itemSeedService)
        {
            _userUnitOfWork = userUnitOfWork;
            _userSeedService = userSeedService;
            _groupSeedService = groupSeedService;
            _itemSeedService = itemSeedService;
        }

        public async Task EnsureDataAsync()
        {
            try
            {
                _userUnitOfWork.BeginTransaction();

                var groups = await _groupSeedService.EnsureGroupsAsync();
                var users = await _userSeedService.EnsureUsersAsync(groups);
                var items = await _itemSeedService.EnsureItemsAsync(users);

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

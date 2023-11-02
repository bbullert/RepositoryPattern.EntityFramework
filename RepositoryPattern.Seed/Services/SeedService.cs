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

        public async Task InitializeAsync()
        {
            var itemSeedService = _itemSeedService.SeedGenerator();
            var userSeedService = _userSeedService.SeedGenerator(itemSeedService);
            var groupSeedService = _groupSeedService.SeedGenerator(userSeedService);

            var groups = groupSeedService.Generate(100);
            await _userUnitOfWork.GroupRepository.AddRangeAsync(groups);

            var users = groups.SelectMany(x => x.Users);
            await _userUnitOfWork.UserRepository.AddRangeAsync(users);

            var items = users.SelectMany(x => x.Items);
            await _userUnitOfWork.ItemRepository.AddRangeAsync(items);

            await _userUnitOfWork.SaveAsync();
        }
    }
}

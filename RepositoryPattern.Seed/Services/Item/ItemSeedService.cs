using Bogus;
using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Seed.Services
{
    public class ItemSeedService : IItemSeedService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public ItemSeedService(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        protected Faker<Item> GetGenerator()
        {
            Random random = new Random();
            var generator = new Faker<Item>()
                .RuleFor(o => o.Name, (f, u) =>
                    "Item#" + random.Next(1, 99999).ToString().PadLeft(5, '0')
                );
            return generator;
        }

        public async Task<IEnumerable<Item>> EnsureItemsAsync(IEnumerable<User> users)
        {
            if (await _userUnitOfWork.ItemRepository.ExistsAsync())
            {
                return await _userUnitOfWork.ItemRepository.GetListAsync(disableTracking: false);
            }

            var random = new Random();
            var items = new List<Item>();
            foreach (var user in users)
            {
                var range = GetGenerator().Generate(random.Next(1, 4));
                items.AddRange(range);
                await _userUnitOfWork.ItemRepository.AddRangeAsync(range);

                user.Items = range.ToList();
                _userUnitOfWork.UserRepository.Update(user);
            }

            await _userUnitOfWork.SaveAsync();
            return items;
        }
    }
}

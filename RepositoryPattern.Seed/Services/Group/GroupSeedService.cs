using Bogus;
using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Seed.Services
{
    public class GroupSeedService : IGroupSeedService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public GroupSeedService(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        protected Faker<Group> GetGenerator()
        {
            Random random = new Random();
            var generator = new Faker<Group>()
                .RuleFor(o => o.Name, (f, u) =>
                    "Group#" + random.Next(1, 99999).ToString().PadLeft(5, '0')
                );
            return generator;
        }

        public async Task<IEnumerable<Group>> EnsureGroupsAsync()
        {
            if (await _userUnitOfWork.GroupRepository.ExistsAsync())
            {
                return await _userUnitOfWork.GroupRepository.GetListAsync(disableTracking: false);
            }

            var groups = GetGenerator().Generate(100);
            await _userUnitOfWork.GroupRepository.AddRangeAsync(groups);

            await _userUnitOfWork.SaveAsync();
            return groups;
        }
    }
}

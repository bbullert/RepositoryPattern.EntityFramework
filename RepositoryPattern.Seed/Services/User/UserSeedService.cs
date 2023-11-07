using Bogus;
using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Seed.Services
{
    public class UserSeedService : IUserSeedService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public UserSeedService(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        protected Faker<User> GetGenerator()
        {
            var generator = new Faker<User>()
                .RuleFor(o => o.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(o => o.LastName, (f, u) => f.Name.LastName())
                .RuleFor(o => o.BirthDate, (f, u) =>
                    f.Date.BetweenDateOnly(new DateOnly(1920, 1, 1), new DateOnly(2005, 1, 1)).ToDateTime(TimeOnly.MinValue)
                );
            return generator;
        }

        public async Task<IEnumerable<User>> EnsureUsersAsync(IEnumerable<Group> groups)
        {
            if (await _userUnitOfWork.UserRepository.ExistsAsync())
            {
                return await _userUnitOfWork.UserRepository.GetListAsync(disableTracking: false);
            }

            var random = new Random();
            var users = new List<User>();
            foreach (var group in groups)
            {
                var range = GetGenerator().Generate(random.Next(2, 8));
                users.AddRange(range);
                await _userUnitOfWork.UserRepository.AddRangeAsync(range);

                group.Users = range.ToList();
                _userUnitOfWork.GroupRepository.Update(group);
            }

            await _userUnitOfWork.SaveAsync();
            return users;
        }
    }
}

using Bogus;
using RepositoryPattern.Data.Entities;
using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Seed.Generators
{
    public partial class UserGenerator
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public UserGenerator(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        public Faker<User> Generate()
        {
            var generator = new Faker<User>()
                .RuleFor(o => o.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(o => o.LastName, (f, u) => f.Name.LastName())
                .RuleFor(o => o.BirthDate, (f, u) => f.Date.Between(
                    new DateTime(1920, 1, 1), new DateTime(2005, 1, 1))
                );
            return generator;
        }

        public IEnumerable<Guid> Add(int size)
        {
            var generator = Generate();
            var users = generator.Generate(size);

            return new List<Guid>();
        }
    }
}

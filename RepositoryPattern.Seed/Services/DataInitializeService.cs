using RepositoryPattern.Data.UoW;
using RepositoryPattern.Seed.Generators;

namespace RepositoryPattern.Seed.Services
{
    public class DataInitializeService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly UserGenerator _userGenerator;
        private readonly GroupGenerator _groupGenerator;
        private readonly ItemGenerator _itemGenerator;

        public DataInitializeService(
            IUserUnitOfWork userUnitOfWork, 
            UserGenerator userGenerator, 
            GroupGenerator groupGenerator, 
            ItemGenerator itemGenerator)
        {
            _userUnitOfWork = userUnitOfWork;
            _userGenerator = userGenerator;
            _groupGenerator = groupGenerator;
            _itemGenerator = itemGenerator;
        }

        public async Task InitializeAsync()
        {
            var itemGenerator = _itemGenerator.GetGenerator();
            var userGenerator = _userGenerator.GetGenerator(itemGenerator);
            var groupGenerator = _groupGenerator.GetGenerator(userGenerator);
            
            var groups = groupGenerator.Generate(50);
            var users = groups.SelectMany(x => x.Users);
            var items = users.SelectMany(x => x.Items);

            await _userUnitOfWork.UserRepository.AddRangeAsync(users);
            await _userUnitOfWork.GroupRepository.AddRangeAsync(groups);
            await _userUnitOfWork.ItemRepository.AddRangeAsync(items);
            await _userUnitOfWork.SaveAsync();
        }
    }
}

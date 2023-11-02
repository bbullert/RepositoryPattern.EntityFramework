using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Seed.Services;

namespace RepositoryPattern.Seed
{
    public static class Bootstrapper
    {
        public static void AddGenerators(this IServiceCollection services)
        {
            services.AddScoped<IUserSeedService, UserSeedService>();
            services.AddScoped<IGroupSeedService, GroupSeedService>();
            services.AddScoped<IItemSeedService, ItemSeedService>();
            services.AddScoped<ISeedService, SeedService>();
        }
    }
}

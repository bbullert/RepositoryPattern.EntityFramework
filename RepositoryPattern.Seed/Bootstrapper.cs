using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Seed.Generators;
using RepositoryPattern.Seed.Services;

namespace RepositoryPattern.Seed
{
    public static class Bootstrapper
    {
        public static void AddGenerators(this IServiceCollection services)
        {
            services.AddScoped<UserGenerator>();
            services.AddScoped<GroupGenerator>();
            services.AddScoped<ItemGenerator>();
            services.AddScoped<DataInitializeService>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Data.Contexts;
using RepositoryPattern.Seed.Services;

namespace RepositoryPattern.Seed
{
    public static class Bootstrapper
    {
        public static void AddSeedServices(this IServiceCollection services)
        {
            services.AddScoped<IUserSeedService, UserSeedService>();
            services.AddScoped<IGroupSeedService, GroupSeedService>();
            services.AddScoped<IItemSeedService, ItemSeedService>();
            services.AddScoped<ISeedService, SeedService>();
        }

        public static async Task EnsureDataAsync(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetService<ApiContext>();
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var relationalDatabaseCreator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (relationalDatabaseCreator == null)
                throw new ArgumentNullException(nameof(relationalDatabaseCreator));

            if (!relationalDatabaseCreator.Exists())
                throw new Exception("Database does not exist.");

            var seedService = scope.ServiceProvider.GetService<ISeedService>();
            if (seedService == null)
                throw new ArgumentNullException(nameof(seedService));

            await seedService.EnsureDataAsync();
        }
    }
}

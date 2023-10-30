using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Data.Repositories;
using RepositoryPattern.Data.UoW;

namespace RepositoryPattern.Data
{
    public static class Bootstrapper
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAuditRepository, UserAuditRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
        }

        public static void AddUnitsOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
        }
    }
}

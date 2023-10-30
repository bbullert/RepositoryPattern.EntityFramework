using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Core.Services;

namespace RepositoryPattern.Core
{
    public static class Bootstrapper
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupUserService, GroupUserService>();
            services.AddScoped<IItemService, ItemService>();
        }
    }
}

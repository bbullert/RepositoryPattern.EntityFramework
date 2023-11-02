using RepositoryPattern.Core.Services;
using RepositoryPattern.Data.Repositories;
using RepositoryPattern.Data.UoW;
using RepositoryPattern.Seed.Generators;

namespace Chat.Api.Extnesions
{
    internal static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupUserService, GroupUserService>();
            services.AddScoped<IItemService, ItemService>();
        }

        public static void RegisterRepositries(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAuditRepository, UserAuditRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

            services.AddScoped<UserGenerator>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            //services.AddScoped<IValidator<UserCreate>, UserCreateValidator>();
            //services.AddScoped<IValidator<ChatCreate>, ChatCreateValidator>();
            //services.AddScoped<IValidator<ChatUserCreate>, ChatUserCreateValidator>();
            //services.AddScoped<IValidator<MessageCreate>, MessageCreateValidator>();
        }
    }
}

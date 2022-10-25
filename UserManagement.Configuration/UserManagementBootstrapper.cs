using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application;
using UserManagement.Application.Contracts.Role;
using UserManagement.Application.Contracts.User;
using UserManagement.Configuration.Permissions;
using UserManagement.Domain.RoleAgg;
using UserManagement.Domain.UserDomin;
using UserManagement.Infrastructure.EFCore;
using UserMangement.Infrastructure.EFCore.Repository;

namespace AccountManagement.Configuration
{
    public class UserManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<IPermissionExposer, UserPermissionExposer>();

            services.AddDbContext<UserContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
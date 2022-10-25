using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManagement.Application;
using MoneyManagement.Application.Contracts.Money;
using MoneyManagement.Domain.MoneyDomin;
using MoneyMangement.Infrastructure.EFCore.Repository;
using UserManagement.Infrastructure.EFCore;

namespace MoneyManagement.Configuration
{
    public class MoneyManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IMoneyApplication, MoneyApplication>();
            services.AddTransient<IMoneyRepository, MoneyRepository>();

            services.AddDbContext<MoneyContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
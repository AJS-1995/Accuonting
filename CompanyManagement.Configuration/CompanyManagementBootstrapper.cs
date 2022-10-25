using CompanyManagement.Application;
using CompanyManagement.Application.Contracts.Company;
using CompanyManagement.Domain.CompanyDomin;
using CompanyMangement.Infrastructure.EFCore;
using CompanyMangement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyManagement.Configuration
{
    public class CompanyManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICompanyApplication, CompanyApplication>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddDbContext<CompanyContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
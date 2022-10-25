using CompanyManagement.Domain.CompanyDomin;
using CompanyMangement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CompanyMangement.Infrastructure.EFCore
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company> Companys { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CompanyMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

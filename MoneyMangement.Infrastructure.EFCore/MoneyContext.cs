using Microsoft.EntityFrameworkCore;
using MoneyManagement.Domain.MoneyDomin;
using MoneyMangement.Infrastructure.EFCore.Mappings;

namespace UserManagement.Infrastructure.EFCore
{
    public class MoneyContext : DbContext
    {
        public DbSet<Money> Moneys { get; set; }

        public MoneyContext(DbContextOptions<MoneyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            var assembly = typeof(MoneyMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Money>().HasData(new Money
            { 
                Id = 1,
                Name = "افغانی",
                Country = "افغانستان",
                ISO_Code = "AFN",
                Symbol = "؋",
                Slug = "افغانی",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 2,
                Name = "ریال",
                Country = "ایران",
                ISO_Code = "IRR",
                Symbol = "ریال",
                Slug = "ریال",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 3,
                Name = "یوآن",
                Country = "چین",
                ISO_Code = "CNY",
                Symbol = "¥",
                Slug = "یوآن",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 4,
                Name = "روپیه",
                Country = "هندوستان",
                ISO_Code = "INR",
                Symbol = "₹",
                Slug = "روپیه",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 5,
                Name = "روپیه",
                Country = "پاکستان",
                ISO_Code = "PKR",
                Symbol = "₨",
                Slug = "روپیه",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 6,
                Name = "یورو",
                Country = "اروپا",
                ISO_Code = "EUR",
                Symbol = "€",
                Slug = "یورو",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 7,
                Name = "پوند",
                Country = "بریتانیا",
                ISO_Code = "GBP",
                Symbol = "£",
                Slug = "پوند",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 8,
                Name = "دلار",
                Country = "ایالات متحده امریکا",
                ISO_Code = "USD",
                Symbol = "$",
                Slug = "دلار",
                User_Id = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 9,
                Name = "لیره",
                Country = "ترکیه",
                ISO_Code = "TRY",
                Symbol = "₺",
                Slug = "لیره",
                User_Id = 1,
            });         
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 10,
                Name = "روبل",
                Country = "روسیه",
                ISO_Code = "RUB",
                Symbol = "₽",
                Slug = "روبل",
                User_Id = 1,
            });
        }
    }
}
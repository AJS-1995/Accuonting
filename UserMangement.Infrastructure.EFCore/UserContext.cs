using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.RoleAgg;
using UserManagement.Domain.UserDomin;
using UserMangement.Infrastructure.EFCore.Mappings;

namespace UserManagement.Infrastructure.EFCore
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            //modelBuilder.Entity<User>().HasIndex(u => u.Mobile).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                NamePersian = "مدیر سیستم",
                Slug = "Admin",
                User_Id = 1,
                Cod = 1,
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "Accountant",
                NamePersian = "حسابدار",
                Slug = "Accountant",
                User_Id = 1,
                Cod = 1,
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = "Viewer",
                NamePersian = "بیننده",
                Slug = "Viewer",
                User_Id = 1,
                Cod = 1,
            });
        }
    }
}
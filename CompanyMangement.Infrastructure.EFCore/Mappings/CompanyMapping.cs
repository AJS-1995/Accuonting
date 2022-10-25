using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CompanyManagement.Domain.CompanyDomin;

namespace CompanyMangement.Infrastructure.EFCore.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companys");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Logo).HasMaxLength(500);
            builder.Property(x => x.Email).HasMaxLength(1000);
            builder.Property(x => x.Mobile).HasMaxLength(20);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Slug).HasMaxLength(200);
        }
    }
}
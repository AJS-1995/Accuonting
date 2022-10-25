using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MoneyManagement.Domain.MoneyDomin;

namespace MoneyMangement.Infrastructure.EFCore.Mappings
{
    public class MoneyMapping : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
            builder.ToTable("Moneys");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x => x.ISO_Code).HasMaxLength(10);
            builder.Property(x => x.Symbol).HasMaxLength(10);
            builder.Property(x => x.Slug).HasMaxLength(200);
        }
    }
}
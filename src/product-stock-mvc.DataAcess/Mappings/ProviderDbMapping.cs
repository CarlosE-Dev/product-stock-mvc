using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.DataAcess.Mappings
{
    public class ProviderDbMapping : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("PS_PROVIDERS");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(225);
            builder.Property(p => p.Document).IsRequired().HasMaxLength(14);
            builder.Property(p => p.ProviderType).IsRequired();

            builder.HasMany(p => p.Products).WithOne(p => p.Provider).HasForeignKey(k => k.ProviderId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

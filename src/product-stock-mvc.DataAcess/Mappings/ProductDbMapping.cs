using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.DataAcess.Mappings
{
    public class ProductDbMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PS_PRODUCTS");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(225);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Image).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.QuantityInStock).IsRequired();

            builder.HasOne(p => p.Provider).WithMany(p => p.Products).HasForeignKey(k => k.ProviderId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

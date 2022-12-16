using Microsoft.EntityFrameworkCore;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.DataAcess.Context
{
    public class ProductStockDbContext : DbContext
    {
        public ProductStockDbContext(DbContextOptions<ProductStockDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductStockDbContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}

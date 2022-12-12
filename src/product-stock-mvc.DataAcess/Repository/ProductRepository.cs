using Microsoft.EntityFrameworkCore;
using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;
using product_stock_mvc.DataAcess.Context;

namespace product_stock_mvc.DataAcess.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductStockDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetAllInStockAsync()
        {
            return await _context.Products
                .AsNoTracking()
                    .Where(q => 
                        q.QuantityInStock > 0)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllOutOfStockAsync()
        {
            return await _context.Products
                .AsNoTracking()
                    .Where(q => 
                        q.QuantityInStock <= 0)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByProviderAsync(Guid providerId)
        {
            return await SearchAsync(p => p.ProviderId == providerId);
        }

        public async Task<Product> GetProductProviderAsync(Guid id)
        {
            return await _context.Products
                .AsNoTracking()
                    .Include(p =>
                        p.Provider)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsProvidersAsync()
        {
            return await _context.Products
                .AsNoTracking()
                    .Include(p =>
                        p.Provider)
                            .OrderBy(p => p.Name)
                                .ToListAsync();
        }
    }
}

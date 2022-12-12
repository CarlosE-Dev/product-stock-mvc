using Microsoft.EntityFrameworkCore;
using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;
using product_stock_mvc.DataAcess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_stock_mvc.DataAcess.Repository
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(ProductStockDbContext context) : base(context) { }

        public async Task<IEnumerable<Provider>> GetActiveProvidersAsync(Guid id)
        {
            return await _context.Providers
                .AsNoTracking().
                    Where(p => 
                        p.IsActive == true)
                            .OrderBy(p => p.Name)
                                .ToListAsync();
        }

        public async Task<Provider> GetProviderProductsAsync(Guid id)
        {
            return await _context.Providers
                .AsNoTracking()
                    .Include(p => p.Products)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

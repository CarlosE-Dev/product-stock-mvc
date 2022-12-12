using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Business.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByProviderAsync(Guid providerId);
        Task<Product> GetProductProviderAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsProvidersAsync();
        Task<IEnumerable<Product>> GetAllOutOfStockAsync();
        Task<IEnumerable<Product>> GetAllInStockAsync();
    }
}

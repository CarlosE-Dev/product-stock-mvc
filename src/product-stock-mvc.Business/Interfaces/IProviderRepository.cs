using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Business.Interfaces
{
    public interface IProviderRepository : IBaseRepository<Provider>
    {
        Task<Provider> GetProviderProductsAsync(Guid id);
        Task<IEnumerable<Provider>> GetActiveProvidersAsync(Guid id);
    }
}

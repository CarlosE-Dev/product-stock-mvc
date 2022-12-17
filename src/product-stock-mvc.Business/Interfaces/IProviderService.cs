using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Business.Interfaces
{
    public interface IProviderService : IDisposable
    {
        Task CreateProvider(Provider provider);
        Task UpdateProvider(Provider provider);
        Task DeleteProvider(Guid id);
    }
}

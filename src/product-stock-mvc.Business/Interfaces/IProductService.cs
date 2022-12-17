using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Business.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}

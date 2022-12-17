using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;
using product_stock_mvc.Business.Validations;

namespace product_stock_mvc.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProduct(Product Product)
        {
            if (!ExecuteValidation(new ProductValidation(), Product))
                return;

            await _productRepository.CreateAsync(Product);
            return;
        }

        public async Task UpdateProduct(Product Product)
        {
            if (!ExecuteValidation(new ProductValidation(), Product))
                return;

            await _productRepository.UpdateAsync(Product);
            return;
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.DeleteAsync(id);

            return;
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}

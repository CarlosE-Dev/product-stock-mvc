using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;
using product_stock_mvc.Business.Validations;

namespace product_stock_mvc.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        public async Task CreateProduct(Product Product)
        {
            if (!ExecuteValidation(new ProductValidation(), Product))
                return;

            return;
        }

        public async Task UpdateProduct(Product Product)
        {
            if (!ExecuteValidation(new ProductValidation(), Product))
                return;

            return;
        }

        public async Task DeleteProduct(Product Product)
        {
            if (!ExecuteValidation(new ProductValidation(), Product))
                return;

            return;
        }
    }
}

using FluentValidation;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Business.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
        }
    }
}

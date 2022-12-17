using FluentValidation;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Business.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .Length(3, 225).WithMessage("The field { PropertyName } must be between 3 and 225 characters")
                .NotEmpty().WithMessage("The field {PropertyName} is required");
            
            RuleFor(p => p.Description)
                .Length(20, 500).WithMessage("The field { PropertyName } must be between 20 and 500 characters")
                .NotEmpty().WithMessage("The field {PropertyName} is required");
            
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("The field {PropertyName} is required");
            
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("The field {PropertyName} is required");
            
            RuleFor(p => p.QuantityInStock)
                .NotEmpty().WithMessage("The field {PropertyName} is required")
                .GreaterThan(0).WithMessage("The field { PropertyName } must be greater than 0");
            
            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("The field {PropertyName} is required");
        }
    }
}

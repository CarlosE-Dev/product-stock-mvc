using FluentValidation;
using product_stock_mvc.Business.Models;
using product_stock_mvc.Business.Models.Enums;

namespace product_stock_mvc.Business.Validations
{
    public class ProviderValidation : AbstractValidator<Provider>
    {
        public ProviderValidation()
        {
            RuleFor(p => p.Name)
                .Length(3, 225).WithMessage("The field { PropertyName} must be between 3 and 225 characters")
                .NotEmpty().WithMessage("The field {PropertyName} is required");

            When(p => p.ProviderType == ProviderType.IndividualPerson, () =>
            {
                RuleFor(p => p.Document.Length)
                .Equal(IndividualDocumentValidation.LengthIndividualDoc)
                .WithMessage("The field document must have {ComparisonValue} digits");

                RuleFor(p => IndividualDocumentValidation.Validate(p.Document))
                .Equal(true)
                .WithMessage("Invalid document");
            });

            When(p => p.ProviderType == ProviderType.LegalPerson, () =>
            {
                RuleFor(p => p.Document.Length)
                .Equal(LegalDocumentValidation.LengthLegalDoc)
                .WithMessage("The field document must have {ComparisonValue} digits");

                RuleFor(p => LegalDocumentValidation.Validate(p.Document))
                .Equal(true)
                .WithMessage("Invalid document");
            });
        }
    }
}

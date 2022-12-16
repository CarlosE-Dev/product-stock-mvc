using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;
using product_stock_mvc.Business.Validations;

namespace product_stock_mvc.Business.Services
{
    public class ProviderService : BaseService, IProviderService
    {
        public async Task CreateProvider(Provider provider)
        {
            if (!ExecuteValidation(new ProviderValidation(), provider))
                return;

            return;
        }

        public async Task UpdateProvider(Provider provider)
        {
            if (!ExecuteValidation(new ProviderValidation(), provider))
                return;

            return;
        }

        public async Task DeleteProvider(Provider provider)
        {
            if (!ExecuteValidation(new ProviderValidation(), provider))
                return;

            return;
        }
    }
}

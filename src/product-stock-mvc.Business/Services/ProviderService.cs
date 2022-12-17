using product_stock_mvc.Business.Interfaces;
using product_stock_mvc.Business.Models;
using product_stock_mvc.Business.Validations;

namespace product_stock_mvc.Business.Services
{
    public class ProviderService : BaseService, IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository, INotifier notifier) : base(notifier)
        {
            _providerRepository = providerRepository;
        }
        public async Task CreateProvider(Provider provider)
        {
            if (!ExecuteValidation(new ProviderValidation(), provider))
                return;

            if (_providerRepository.SearchAsync(p => p.Document == provider.Document).Result.Any())
            {
                Notify("Document already registered in our database");
                return;
            }

            await _providerRepository.CreateAsync(provider);

            return;
        }

        public async Task UpdateProvider(Provider provider)
        {
            if (!ExecuteValidation(new ProviderValidation(), provider))
                return;

            if (_providerRepository.SearchAsync(p => p.Document == provider.Document && p.Id != provider.Id).Result.Any())
            {
                Notify("Document already registered in our systems");
                return;
            }

            await _providerRepository.UpdateAsync(provider);

            return;
        }

        public async Task DeleteProvider(Guid id)
        {

            if (_providerRepository.GetProviderProductsAsync(id).Result.Products.Any())
            {
                Notify("The provider has products registered in our systems");
                return;
            }
            await _providerRepository.DeleteAsync(id);
            return;
        }

        public void Dispose()
        {
            _providerRepository?.Dispose();
        }
    }
}

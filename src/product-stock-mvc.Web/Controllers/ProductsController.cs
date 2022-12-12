using Microsoft.AspNetCore.Mvc;
using product_stock_mvc.Web.DTOs;
using product_stock_mvc.Business.Interfaces;
using AutoMapper;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IProviderRepository providerRepository, IMapper mapper)
        {
            _productRepository = repository;
            _providerRepository = providerRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsProvidersAsync()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productDTO = await GetProductProvider(id);

            if (productDTO == null)
                return NotFound();

            return View(productDTO);
        }

        public async Task<IActionResult> Create()
        {
            var productDTO = await FillProvidersList(new ProductDTO());

            return View(productDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            productDTO = await FillProvidersList(productDTO);
            
            if (!ModelState.IsValid)
                return View(productDTO);

            await _productRepository.CreateAsync(_mapper.Map<Product>(productDTO));

            return View(productDTO);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var productDTO = await GetProductProvider(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            productDTO = await FillProvidersList(productDTO);

            return View(productDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return NotFound();

            productDTO = await FillProvidersList(productDTO);

            if (!ModelState.IsValid)
                return View(productDTO);

            await _productRepository.UpdateAsync(_mapper.Map<Product>(productDTO));

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var productDTO = await GetProductProvider(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            return View(productDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productDTO = await GetProductProvider(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        private async Task<ProductDTO> GetProductProvider(Guid id)
        {
            var productDTO = _mapper.Map<ProductDTO>(await _productRepository.GetProductProviderAsync(id));
            productDTO.Providers = _mapper.Map<IEnumerable<ProviderDTO>>(await _providerRepository.GetAllAsync());
            return productDTO;
        }

        private async Task<ProductDTO> FillProvidersList(ProductDTO productDTO)
        {
            productDTO.Providers = _mapper.Map<IEnumerable<ProviderDTO>>(await _providerRepository.GetAllAsync());
            return productDTO;
        }
    }
}

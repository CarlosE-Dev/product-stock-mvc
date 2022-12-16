using Microsoft.AspNetCore.Mvc;
using product_stock_mvc.Web.DTOs;
using product_stock_mvc.Business.Interfaces;
using AutoMapper;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Web.Controllers
{
    [Route("product")]
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

        [Route("list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsProvidersAsync()));
        }

        [Route("details")]
        public async Task<IActionResult> Details(Guid id)
        {
            var productDTO = await GetProductProvider(id);

            if (productDTO == null)
                return NotFound();

            return View(productDTO);
        }

        [Route("new")]
        public async Task<IActionResult> Create()
        {
            var productDTO = await FillProvidersList(new ProductDTO());

            return View(productDTO);
        }

        [Route("new")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            productDTO = await FillProvidersList(productDTO);
            
            if (!ModelState.IsValid)
                return View(productDTO);

            var imgPrefix = Guid.NewGuid() + "_";

            if (!await UploadFile(productDTO.ImageUpload, imgPrefix)) {
                return View(productDTO);
            }

            productDTO.Image = imgPrefix + productDTO.ImageUpload.FileName;

            await _productRepository.CreateAsync(_mapper.Map<Product>(productDTO));

            return RedirectToAction("Index");
        }

        [Route("update/{id:guid}")]
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

        [Route("update/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return NotFound();

            var updateProduct = await GetProductProvider(id);
            var updateProductProviders = FillProvidersList(updateProduct);

            if (!ModelState.IsValid)
                return View(updateProductProviders);

            if(productDTO.ImageUpload != null)
            {
                var imgPrefix = Guid.NewGuid() + "_";

                if (!await UploadFile(productDTO.ImageUpload, imgPrefix))
                {
                    return View(productDTO);
                }

                productDTO.Image = imgPrefix + productDTO.ImageUpload.FileName;
            }
            else
            {
                productDTO.Image = updateProduct.Image;
            }

            await _productRepository.UpdateAsync(_mapper.Map<Product>(productDTO));

            return RedirectToAction("Index");
        }

        [Route("remove/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productDTO = await GetProductProvider(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            return View(productDTO);
        }

        [Route("remove/{id:guid}")]
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

        private async Task<bool> UploadFile(IFormFile file, string prefix)
        {
            if (file.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", prefix + file.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Error! Duplicated file");
                return false;
            }

            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using product_stock_mvc.Web.DTOs;
using product_stock_mvc.Business.Interfaces;
using AutoMapper;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Web.Controllers
{
    public class ProvidersController : BaseController
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<ProviderDTO>>(await _repository.GetAllAsync()));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var providerDTO = _mapper.Map<ProviderDTO>(await _repository.GetProviderProductsAsync(id));

            if (providerDTO == null)
            {
                return NotFound();
            }

            return View(providerDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderDTO providerDTO)
        {
            if (!ModelState.IsValid) 
                return View(providerDTO);

            var provider = _mapper.Map<Provider>(providerDTO);
            await _repository.CreateAsync(provider);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var providerDTO = _mapper.Map<ProviderDTO>(await _repository.GetProviderProductsAsync(id));

            if (providerDTO == null)
                return NotFound();

            return View(providerDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProviderDTO providerDTO)
        {
            if (id != providerDTO.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(providerDTO);

            await _repository.UpdateAsync(_mapper.Map<Provider>(providerDTO));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var providerDTO = _mapper.Map<ProviderDTO>(await _repository.GetByIdAsync(id));

            if (providerDTO == null)
                return NotFound();

            return View(providerDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var provider = await _repository.GetByIdAsync(id);

            if (provider == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}

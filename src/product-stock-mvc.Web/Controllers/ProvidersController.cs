using Microsoft.AspNetCore.Mvc;
using product_stock_mvc.Web.DTOs;
using product_stock_mvc.Business.Interfaces;
using AutoMapper;
using product_stock_mvc.Business.Models;

namespace product_stock_mvc.Web.Controllers
{
    [Route("provider")]
    public class ProvidersController : BaseController
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProvidersController( IProviderRepository providerRepository, 
                                    IMapper mapper, 
                                    IProviderService providerService,
                                    INotifier notifier
                                    ) : base(notifier)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
            _providerService = providerService;
        }

        [Route("list")]
        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<ProviderDTO>>(await _providerRepository.GetAllAsync()));
        }

        [Route("details")]
        public async Task<IActionResult> Details(Guid id)
        {

            var providerDTO = _mapper.Map<ProviderDTO>(await _providerRepository.GetProviderProductsAsync(id));

            if (providerDTO == null)
            {
                return NotFound();
            }

            return View(providerDTO);
        }

        [Route("new")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("new")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderDTO providerDTO)
        {
            if (!ModelState.IsValid) 
                return View(providerDTO);

            var provider = _mapper.Map<Provider>(providerDTO);
            await _providerService.CreateProvider(provider);

            if (!ValidOperation()) return View(providerDTO);

            TempData["Success"] = "Provider successfully created";

            return RedirectToAction("Index");
        }

        [Route("update/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var providerDTO = _mapper.Map<ProviderDTO>(await _providerRepository.GetProviderProductsAsync(id));

            if (providerDTO == null)
                return NotFound();

            return View(providerDTO);
        }

        [Route("update/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProviderDTO providerDTO)
        {
            if (id != providerDTO.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                var updateProvider = await _providerRepository.GetProviderProductsAsync(id);
                return View(updateProvider);
            }

            await _providerService.UpdateProvider(_mapper.Map<Provider>(providerDTO));

            if (!ValidOperation()) return View(_mapper.Map<ProviderDTO>(await _providerRepository.GetProviderProductsAsync(id)));

            TempData["Success"] = "Provider successfully updated";

            return RedirectToAction("Index");
        }

        [Route("remove/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var providerDTO = _mapper.Map<ProviderDTO>(await _providerRepository.GetByIdAsync(id));

            if (providerDTO == null)
                return NotFound();

            return View(providerDTO);
        }

        [Route("remove/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);

            if (provider == null)
                return NotFound();

            await _providerService.DeleteProvider(id);

            if (!ValidOperation()) return View(_mapper.Map<ProviderDTO>(provider));

            TempData["Success"] = "Provider successfully removed";

            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using product_stock_mvc.Web.DTOs;
using System.Diagnostics;

namespace product_stock_mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Message = "Please, try again later or contact our support.";
                modelErro.Title = "An error ocurred! <br />";
                modelErro.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelErro.Message = "Contact our support for more information.";
                modelErro.Title = "Oops! Page not found. <br />";
                modelErro.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelErro.Message = "You do not have permission to access this content.";
                modelErro.Title = "Access denied. <br />";
                modelErro.ErrorCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using product_stock_mvc.Business.Interfaces;

namespace product_stock_mvc.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotifier _notifier;
        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }
    }
}

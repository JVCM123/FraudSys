using FraudSys.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace FraudSys.MVC.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(Notifier notifier) : base(notifier)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

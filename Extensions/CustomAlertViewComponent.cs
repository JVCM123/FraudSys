using Microsoft.AspNetCore.Mvc;

namespace FraudSys.MVC.Extensions
{
    public class CustomAlertViewComponent : ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

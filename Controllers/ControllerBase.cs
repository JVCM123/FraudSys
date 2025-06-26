using FraudSys.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace FraudSys.MVC.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly Notifier _notifier;

        public ControllerBase(Notifier notifier)
        {
            _notifier = notifier;
        }

        protected void SetErrors()
        {
            TempData["Erro"] = string.Join("\n", _notifier.Notifications.Select(n => n.Message));
        }

        protected void SetSuccess()
        {
            TempData["Sucesso"] = string.Join("\n", _notifier.Notifications.Select(n => n.Message));
        }
    }
}

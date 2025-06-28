using FraudSys.Application.Contexts.TransferenciasContext.Commands;
using FraudSys.Application.ViewModel;
using FraudSys.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FraudSys.MVC.Controllers
{
    public class TransferenciaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransferenciaController(Notifier notifier, IMediator mediator) : base(notifier)
        {
            _mediator = mediator;
        }

        [HttpGet("adicionar-transferencia")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("adicionar-transferencia")]
        public async Task<IActionResult> Create([FromForm] TransferenciaPixViewModel transferencia)
        {
            if (!ModelState.IsValid)
                return View(transferencia);

            if (!await _mediator.Send(new RealizarTransferenciaPixCommand(transferencia)))
            {
                SetErrors();

                return View(transferencia);
            }

            SetSuccess();

            return RedirectToAction("Index","Home");
        }
    }
}

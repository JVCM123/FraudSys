using FraudSys.Application.Contexts.ContaCorrenteLimiteContext.Commands;
using FraudSys.Application.ViewModel;
using FraudSys.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FraudSys.MVC.Controllers
{
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Notifier _notifier;

        public ContaCorrenteController(IMediator mediator, Notifier notifier) : base(notifier)
        {
            _mediator = mediator;
            _notifier = notifier;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContaCorrenteLimiteViewModel filtro)
        {
            if (filtro.NumConta is null or <= 0 || filtro.NumAgencia is null or <= 0)
            {
                _notifier.AddNotification("Informe número da conta e agência para a busca.");
                SetErrors();

                return View();
            }

            var resultado = await _mediator.Send(new GetContaCorrenteLimiteByIdCommand((int)filtro.NumAgencia, (int)filtro.NumConta));

            if (resultado is null)
            {
                SetErrors();
                return View();
            }

            return View(resultado);
        }

        [HttpGet("criar-conta")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("criar-conta")]
        public async Task<IActionResult> Create([FromForm] ContaCorrenteLimiteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!await _mediator.Send(new AdicionarContaCorrenteLimiteCommand(model)))
            {
                SetErrors();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("editar-conta/{agencia}/{conta}")]
        public async Task<IActionResult> Edit(int agencia, int conta)
        {
            var model = await _mediator.Send(new GetContaCorrenteLimiteByIdCommand(agencia, conta));

            if (model is null)
                return NotFound();

            return View(model);
        }

        [HttpPost("editar-conta/{agencia}/{conta}")]
        public async Task<IActionResult> Edit(ContaCorrenteLimiteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!await _mediator.Send(new AtualizarContaCorrenteLimiteCommand(model)))
            {
                SetErrors();
                return View(model);
            }

            return RedirectToAction("Details", new { agencia = model.NumAgencia, conta = model.NumConta });
        }

        [HttpGet("detalhes-conta/{agencia}/{conta}")]
        public async Task<IActionResult> Details(int agencia, int conta)
        {
            var model = await _mediator.Send(new GetContaCorrenteLimiteByIdCommand(agencia, conta));

            if (model is null)
                return NotFound();

            return View(model);
        }
    }
}


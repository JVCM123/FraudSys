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

        public ContaCorrenteController(IMediator mediator, Notifier _notifer) : base(_notifer)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            TempData["Sucesso"] = "Teste de erro";
            return View();
        }

        [HttpPost("buscar-conta")]
        public async Task<IActionResult> Index(ContaCorrenteLimiteViewModel filtro)
        {
            var resultado = await _mediator.Send(new GetContaCorrenteLimiteByIdCommand(filtro.NumAgencia, filtro.NumConta));

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
        public async Task<IActionResult> Create(ContaCorrenteLimiteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var sucesso = await _mediator.Send(new AdicionarContaCorrenteLimiteCommand(model));

            if (!sucesso)
            {
                SetErrors();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("editar-conta")]
        public async Task<IActionResult> Edit(int agencia, int conta)
        {
            var model = await _mediator.Send(new GetContaCorrenteLimiteByIdCommand(agencia, conta));

            if (model is null)
                return NotFound();

            return View(model);
        }

        [HttpPost("editar-conta")]
        public async Task<IActionResult> Edit(ContaCorrenteLimiteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var sucesso = await _mediator.Send(new AtualizarContaCorrenteLimiteCommand(model));

            if (!sucesso)
            {
                SetErrors();
                return View(model);
            }

            return RedirectToAction("Details", new { agencia = model.NumAgencia, conta = model.NumConta });
        }

        [HttpGet("detalhes-conta")]
        public async Task<IActionResult> Details(int agencia, int conta)
        {
            var model = await _mediator.Send(new GetContaCorrenteLimiteByIdCommand(agencia, conta));

            if (model is null)
                return NotFound();

            return View(model);
        }
    }
}


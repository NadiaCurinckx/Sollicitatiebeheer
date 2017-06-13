using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sollicitatiebeheer.Web.Features.Vacatures {

    [Route("[controller]")]
    public class VacaturesController : Controller {

        private readonly IMediator _mediator;

        public VacaturesController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("index")]
        public async Task<IActionResult> Index(Index.Request request) {
            var model = await _mediator.Send(request);
            return View(model);
        }

        [HttpGet]
        [Route("toevoegen")]
        public async Task<IActionResult> Toevoegen(Toevoegen.Request request)
        {
            var model = await _mediator.Send(request);
            return View(model);
        }

        [HttpPost]
        [Route("bewaren")]
        public async Task<IActionResult> Bewaren(Bewaren.Request request)
        {
            var model = await _mediator.Send(request);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("verwijderen")]
        public async Task<IActionResult> Verwijderen(Verwijderen.Request request)
        {
            var model = await _mediator.Send(request);
            return RedirectToAction("index");
        }
    }
}

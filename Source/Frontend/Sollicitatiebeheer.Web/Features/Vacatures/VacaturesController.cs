using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sollicitatiebeheer.Model.Afdelingen;
using Sollicitatiebeheer.Model.Vacatures;

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
        public async Task<IActionResult> Toevoegen(Toevoegen.Request request) {
            var model = await _mediator.Send(request);
            return View(model);
        }

        [HttpGet]
        [Route("bewerken")]
        public async Task<IActionResult> Bewerken(Bewerken.Request request) {
            var model = await _mediator.Send(request);
            return View(model);
        }

        [HttpPost]
        [Route("bewaren")]
        public IActionResult Bewaren(VacatureDetail request) {
            var model = _mediator.Send(new Bewaren.Request { Vacature = request.Vacature, AfdelingId = Int32.Parse(request.GeselecteerdeAfdeling) });
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("verwijderen")]
        public async Task<IActionResult> Verwijderen(Verwijderen.Request request) {
            var model = await _mediator.Send(request);
            return RedirectToAction("index");
        }
    }
}

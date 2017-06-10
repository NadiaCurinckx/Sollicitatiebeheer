using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sollicitatiebeheer.Web.Features.Vacatures {

    [Route("")]
    public class VacaturesController : Controller {

        private readonly IMediator _mediator;

        public VacaturesController(IMediator mediator) {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(Index.Request request) {
            var model = await _mediator.Send(request);
            return View(model);
        }
    }
}

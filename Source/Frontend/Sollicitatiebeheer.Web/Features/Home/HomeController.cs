using Microsoft.AspNetCore.Mvc;

namespace Sollicitatiebeheer.Web.Features.Home {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}

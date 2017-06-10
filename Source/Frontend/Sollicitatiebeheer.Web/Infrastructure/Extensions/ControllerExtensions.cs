using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sollicitatiebeheer.Web.Infrastructure.Extensions {
    /// <summary>
    /// Provides extension methods for a given <see cref="Controller"/> class.
    /// </summary>
    public static class ControllerExtensions {
        public static IActionResult JsonResult(this Controller controller, object model) {
            var serialized = JsonConvert.SerializeObject(model,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return new ContentResult { Content = serialized, ContentType = "application/json" };
        }
    }
}

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Sollicitatiebeheer.Web.Infrastructure.Validation {
    public class ValidatorActionFilter : IActionFilter {
        public void OnActionExecuting(ActionExecutingContext context) {
            var controller = context.Controller as Controller;

            if (controller == null)
                return;

            if (controller.ViewData.ModelState.IsValid)
                return;

            if (controller.HttpContext.Request.Method == "GET") {
                context.Result = new StatusCodeResult((int)HttpStatusCode.BadRequest);
            } else {
                var result = new ContentResult();
                var content = JsonConvert.SerializeObject(
                    controller.ViewData.ModelState,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
                );

                result.Content = content;
                result.ContentType = "application/json";

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = result;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

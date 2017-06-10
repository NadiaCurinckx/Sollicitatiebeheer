using System;
using System.Net;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Sollicitatiebeheer.Web.Infrastructure.Validation {
    public class ValidatorActionFilter : IActionFilter {
        private readonly ILogger<ValidatorActionFilter> _logger;

        public ValidatorActionFilter(ILogger<ValidatorActionFilter> logger) {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            var controller = context.Controller as Controller;

            if (controller == null)
                return;

            if (controller.ViewData.ModelState.IsValid)
                return;

            try {
                _logger.LogError($"Error occured during request '{context.HttpContext.Request.GetEncodedUrl()}'.");

                var result = new ContentResult();
                var content = JsonConvert.SerializeObject(
                    controller.ViewData.ModelState,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
                );

                result.Content = content;
                result.ContentType = "application/json";

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = result;
            } catch (Exception ex) {
                _logger.LogError($"Error occured during processing error for request '{context.HttpContext.Request.GetEncodedUrl()}'.");
                context.Result = new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

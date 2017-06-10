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

                var result = new ViewResult {
                    ViewName = "_Error",
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ViewData = controller.ViewData,
                    TempData = controller.TempData
                };

                context.HttpContext.Response.StatusCode = (int)result.StatusCode;
                context.Result = result;
            } catch (Exception ex) {
                _logger.LogError($"Error occured during processing error for request '{context.HttpContext.Request.GetEncodedUrl()}'.");
                context.Result = new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

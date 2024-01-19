using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace AdminClient.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statuscode}")]
        public IActionResult HttpErrorCodeHandler(int statuscode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statuscode)
            {
                case 404:
                    logger.LogError($"404 Error occured at {statusCodeResult.OriginalPath} and QueryString={statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }

        [Route("Error/exception")]
        public IActionResult Error()
        {
            var exceptionDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"The Exception path={exceptionDetail.Path} and Exception Message={exceptionDetail.Error.Message}");

            return View("Error");
        }
        

    }
}

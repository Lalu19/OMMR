using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClient.AppHelper
{
    public class CheckSession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //base.OnActionExecuting(context);

            var userIdSession = context.HttpContext.Session.GetInt32("UserId");
            if (userIdSession == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Message" },
                                { "Action", "SessionExpire"}
                                });
            }
            else
            {
                string appMenu = context.HttpContext.Session.GetString("AppMenu");
                var currentUrl = context.HttpContext.Request.GetDisplayUrl();
                string absolutePath = new Uri(currentUrl).AbsolutePath;

                if (!appMenu.Contains(absolutePath))
                {
                    context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Message" },
                                { "Action", "NotAssinged"}
                                });
                }
            }
        }
    }
}

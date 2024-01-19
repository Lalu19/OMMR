using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminClient.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }
        public IActionResult SessionExpire()
        {
            ViewBag.Title = "Session Expired";          
            ViewBag.Detail = "Your current session has expired.you may return to Login to start your task again.";
            _logger.LogError("Session Expired,Detail: Your current session has expired.you may return to Login to start your task again.");
            return View("Common");
        }
        public IActionResult NotAssinged()
        {
            ViewBag.Title = "Not Assign";
            ViewBag.Detail = "You have no permission for this task or not assinged by Admin.";
            _logger.LogError("Not Assign,Detail: You have no permission for this task or not assinged by Admin.you may return to Login to start your task again.");
            return View("Common");
        }
        public IActionResult TokenExpire()
        {
            ViewBag.Title = "Token Expired";
            ViewBag.Detail = "Your current token has expired.you have to Login again to get a new token and start your task again.";
            _logger.LogError($"User ID:{HttpContext.Session.GetInt32("UserId")},Name:{HttpContext.Session.GetString("FullName")},Detail: Your current token has expired.you have to Login again to get a new token and start your task again.");
            return View("Common");
        }
        public IActionResult Unauthorize()
        {
            ViewBag.Title = "Token Expired";
            ViewBag.Detail = "You are not authorize for this task.you may contact to admin to get access for this task" +
                " and login again to start your task";
            _logger.LogError($"User ID:{HttpContext.Session.GetInt32("UserId")},Name:{HttpContext.Session.GetString("FullName")},Detail: You are not authorize for this task.you may contact to admin to get access for this task and login again to start your task");
            return View("Common");
        }
    }
}

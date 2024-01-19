using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminClient.AppHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminClient.Controllers
{
    [CheckSession]
    public class DashBoardController : Controller
    {       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

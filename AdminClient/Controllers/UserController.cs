using System;
using System.Collections.Generic;
using AdminClient.AppHelper;

using Microsoft.AspNetCore.Mvc;


namespace AdminClient.Controllers
{
    [CheckSession]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult RoleList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

      
    }
}

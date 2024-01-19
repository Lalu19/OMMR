using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class StateUserController : Controller
    {
        public IActionResult StateUserCreate()
        {
            return View(); 
        }
        public IActionResult StateUserList()
        {
            return View();
        }
        public IActionResult StateUserEdit(int stateUserId)
        {
            ViewBag.stateUserId = stateUserId;
            return View();
        }
        public IActionResult StateAdminDeletion()
        {
            return View();
        }
    }
}

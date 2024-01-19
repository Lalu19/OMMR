using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class HallPassController : Controller
    {
        public IActionResult HallPassCreate()
        {
            return View();
        }
        
        public IActionResult HallPassList()
        {
            return View();
        }
        public IActionResult HallPassEdit(int hallPassId)
        {
            ViewBag.hallPassId = hallPassId;
            return View();
        }
    }
}

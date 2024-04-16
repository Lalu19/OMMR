using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class VerdictController : Controller
    {
        public IActionResult CreateVerdict()
        {
            return View();
        }
        public IActionResult VerdictList()
        {
            return View();
        }
        public IActionResult VerdictEdit(int verdictId)
        {
            ViewBag.verdictId = verdictId;
            return View();
        }
    }
}

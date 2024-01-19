using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class OptionController : Controller
    {
        public IActionResult OptionCreate()
        {
            return View(); 
        }
        public IActionResult OptionList()
        {
            return View();
        }
        public IActionResult OptionEdit(int optionsId)
        {
            ViewBag.optionsId = optionsId;
            return View();
        }
    }
}

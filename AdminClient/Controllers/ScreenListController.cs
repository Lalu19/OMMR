using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class ScreenListController : Controller
    {
        public IActionResult UploadScreenList()
        {
            return View();
        }
        public IActionResult UploadScreenListView()
        {
            return View();
        }
        public IActionResult ScreenListView()
        {
            return View();
        }
    }
}

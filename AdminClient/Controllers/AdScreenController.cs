using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class AdScreenController : Controller
    {
        public IActionResult AdScreenUpload()
        {
            return View();
        }
        public IActionResult AdScreenListView()
        {
            return View();
        }
        public IActionResult ActiveScreenListView()
        {
            return View();
        }

        public IActionResult TaskAssignList()
        {
            return View();
        }

        public IActionResult TheaterList()
        {
            return View();
        }
        public IActionResult AgentFeedbackFormList()
        {
            return View();
        }
    }
}

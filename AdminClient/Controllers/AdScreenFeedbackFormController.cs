using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class AdScreenFeedbackFormController : Controller
    {
        public IActionResult AdScreenFeedbackFormList()
        {
            return View();
        }
        public IActionResult AdScreenFeedbackFormListforadmin()
        {
            return View();
        }
        //public IActionResult AdScreenFeedbackFormEditforadmin(int adScreenFeedbackFormId)
        //{
        //    ViewBag.adScreenFeedbackFormId = adScreenFeedbackFormId;
        //    return View();
        //}
        public IActionResult ClientsAdscreenFeedbackList()
        {
            return View();
        }
    }
}

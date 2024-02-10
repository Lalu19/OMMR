using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class ReportController : Controller
    {
        //Reports
        public IActionResult AllActiveScreenListView()
        {
            return View();
        }
        public IActionResult AdvertiseListView()
        {
            return View();
        }
        public IActionResult StateAdminListView()
        {
            return View();
        }
        public IActionResult AdminListView()
        {
            return View();
        }
        public IActionResult ClientListView()
        {
            return View();
        }
        public IActionResult AllUserList()
        {
            return View();
        }
        public IActionResult StateAdminListViewforSuperAdmin()
        {
            return View();
        }
        public IActionResult ClientFilterListView()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}

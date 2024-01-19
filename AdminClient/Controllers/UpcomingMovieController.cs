using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class UpcomingMovieController : Controller
    {
        public IActionResult UpcomingMovieCreate()
        {
            return View();
        }
        public IActionResult UpcomingMovieList()
        {
            return View();
        }
        public IActionResult UpcomingMovieEdit(int upcomingMovieId)
        {
            ViewBag.upcomingMovieId = upcomingMovieId;
            return View();
        }

        public IActionResult UpcomingMoviePosters()
        {
            return View();
        }
        public IActionResult UpcomingMovieExcelUpload()
        {
            return View();
        }
        public IActionResult UpcomingMovieListView()
        {
            return View();
        }
    }
}

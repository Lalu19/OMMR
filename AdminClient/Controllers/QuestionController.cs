using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult QuestionCreate()
        {
            return View(); 
        }
        public IActionResult QuestionList()
        {
            return View();
        }
        public IActionResult QuestionEdit(int questionTableId)
        {
            ViewBag.questionTableId = questionTableId;
            return View();
        }

        public IActionResult AnswerList()
        {
            return View();
        }
    }
}

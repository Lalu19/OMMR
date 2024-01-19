using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
	public class PrivacyPolicyController : Controller
	{
		public IActionResult PrivacyPolicy()
		{
			return View();
		}
        public IActionResult TermsandCondition()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult CreateAgent()
        {
            return View();
        }
        public IActionResult AgentList()
        {
            return View();
        }
        public IActionResult AgentEdit(int agentId)
        {
            ViewBag.agentId = agentId;
            return View();
        }
       
        public IActionResult AgentCreateByAdmin()
        {
            return View();
        }
        public IActionResult AgentListByAdmin()
        {
            return View();
        }
        public IActionResult AgentEditByAdmin(int agentId)
        {
            ViewBag.agentId = agentId;
            return View();
        }
        
        public IActionResult AgentDeletion()
        {
            return View();
        }
        public IActionResult AgentNotificationInspection()
        {
            return View();
        }
        public IActionResult AgentNotificationInspectionforAdmin()
        {
            return View();
        }
    }
}

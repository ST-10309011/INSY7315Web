using Microsoft.AspNetCore.Mvc;

namespace AfterGrad.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index(string consultantId)
        {
            // **IMPORTANT: Enable back button for mobile view**
            ViewData["ShowBackButton"] = "true";

            ViewData["ConsultantId"] = consultantId;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(string message, string consultantId)
        {
            // Logic to save the message
            return RedirectToAction(nameof(Index), new { consultantId });
        }
    }
}
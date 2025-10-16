using AfterGrad.Models;
using Microsoft.AspNetCore.Mvc; // <-- FIX: Added missing using statement

namespace AfterGrad.Controllers
{
    public class MessagesController : Controller // <-- FIX: Ensure inheritance is correct
    {
        // Simulated List of Previous Messages MUST be INSIDE the class
        private List<BroadcastMessageVM> GetPreviousMessages() => new List<BroadcastMessageVM> // Error CS0246 fixed (VM not found)
        {
            new BroadcastMessageVM { Title = "System Update 1.5", SelectedAudience = "All Users", Message = "System will be down tonight." },
            new BroadcastMessageVM { Title = "New Consultant Available", SelectedAudience = "Students", Message = "We have added a new expert." }
        };

        public IActionResult Index()
        {
            ViewBag.PreviousMessages = GetPreviousMessages();
            return View(new BroadcastMessageVM());
        }

        public IActionResult BroadcastForm()
        {
            ViewData["ShowBackButton"] = "true";
            return View(new BroadcastMessageVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Broadcast(BroadcastMessageVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = $"Message '{model.Title}' broadcast to {model.SelectedAudience} successfully.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.PreviousMessages = GetPreviousMessages();
            return View("Index", model); // Error CS0103/CS0116 fixed
        }
    }
}
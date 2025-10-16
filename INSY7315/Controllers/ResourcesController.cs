using AfterGrad.Models;
using Microsoft.AspNetCore.Mvc; // <-- FIX: Added missing using statement
using System.Collections.Generic; // You might need this if List<T> isn't recognized globally

namespace AfterGrad.Controllers
{
    public class ResourcesController : Controller // <-- FIX: Ensure inheritance is correct
    {
        // Simulated List of Resources MUST be INSIDE the class
        private List<ResourceVM> GetResources() => new List<ResourceVM> // Error CS0246 fixed (VM not found)
        {
            new ResourceVM { Title = "Thesis Formatting Guide", Type = "PDF", Description = "University Standard" },
            new ResourceVM { Title = "Data Analysis Templates", Type = "Excel", Description = "Statistical Methods" }
        };

        public IActionResult Index()
        {
            ViewBag.ExistingResources = GetResources();
            return View(new ResourceUploadVM());
        }

        public IActionResult UploadForm()
        {
            ViewData["ShowBackButton"] = "true";
            return View(new ResourceUploadVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(ResourceUploadVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = $"Resource '{model.Title}' uploaded successfully.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ExistingResources = GetResources();
            return View("Index", model); // Error CS0103/CS0116 fixed
        }
    }
}
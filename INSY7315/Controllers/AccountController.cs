using AfterGrad.Models;
using Microsoft.AspNetCore.Mvc;

namespace AfterGrad.Controllers
{
    public class AccountController : Controller
    {
        // Landing Page
        public IActionResult Landing()
        {
            return View();
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // **Authentication Logic Simulation:**
                // Use actual authentication/database check here.

                if (model.Email == "admin@ag.com" && model.Password == "password")
                {
                    // Successful login redirects to Dashboard
                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        // GET: /Account/SignUp
        public IActionResult SignUp()
        {
            return View(new SignUpVM());
        }

        // POST: /Account/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                // **Registration Logic Simulation:**
                // Save new user to database here.

                TempData["Message"] = "Registration successful. Please log in.";
                return RedirectToAction(nameof(Login));
            }
            return View(model);
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            // Clear authentication cookie/token here.
            return RedirectToAction(nameof(Landing));
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
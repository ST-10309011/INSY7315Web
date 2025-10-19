using INSY7315.Models;
using INSY7315.Services;
using Microsoft.AspNetCore.Mvc;

namespace INSY7315.Controllers
{
    public class AccountController : Controller
    {
        private readonly FirestoreService _dbService;

        // Dependency Injection: Inject the FirestoreService
        public AccountController(FirestoreService dbService)
        {
            _dbService = dbService;
        }

        // -----------------------------------------------------------------
        // GET ACTIONS
        // -----------------------------------------------------------------
        public IActionResult Landing() => View();
        public IActionResult Login() => View();
        public IActionResult SignUp() => View();

        // -----------------------------------------------------------------
        // POST: Login (Handles form submission and INSECURE authentication)
        // -----------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // 1. Find user by email
                var user = await _dbService.GetUserByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                // 2. INSECURE: Plain-text password comparison
                if (user.Password == model.Password)
                {
                    // Authentication is successful!

                    // TODO: Implement ASP.NET Core Identity or simple Session/Cookie Authentication
                    TempData["Message"] = $"Welcome back, {user.Email}!";
                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            // If we got this far, something failed, re-display form
            return View(model);
        }

        // -----------------------------------------------------------------
        // POST: Register (Handles form submission and user creation)
        // -----------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                // 1. Check if user already exists
                var existingUser = await _dbService.GetUserByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "An account already exists with this email address.");
                    return View(model);
                }

                // 2. Create the new UserModel
                var newUser = new UserModel
                {
                    Email = model.Email,
                    Password = model.Password, // INSECURE: Saving the plain text password
                    StudentNumber = model.StudentNumber,
                    Role = "student",
                    Uid = Guid.NewGuid().ToString()
                };

                // 3. Register the user in Firestore
                string documentId = await _dbService.RegisterUserAsync(newUser);

                if (documentId != null)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please log in.";
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            }

            return View(model);
        }

        // -----------------------------------------------------------------
        // GET: Logout
        // -----------------------------------------------------------------
        public IActionResult Logout()
        {
            // TODO: Clear authentication cookies/sessions
            TempData["Message"] = "You have been logged out.";
            return RedirectToAction("Landing");
        }
    }
}
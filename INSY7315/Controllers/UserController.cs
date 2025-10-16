using AfterGrad.Models;
using Microsoft.AspNetCore.Mvc;

namespace AfterGrad.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/Profile
        public IActionResult Profile()
        {
            return View(new ProfileVM());
        }

        // POST: /User/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(ProfileVM model)
        {
            TempData["Message"] = "Profile updated successfully.";
            return RedirectToAction(nameof(Profile));
        }

        // GET: /User/ChangePassword
        public IActionResult ChangePassword()
        {
            ViewData["ShowBackButton"] = "true";
            return View(new ChangePasswordVM());
        }

        // POST: /User/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Password changed successfully.";
                return RedirectToAction(nameof(Profile));
            }
            ViewData["ShowBackButton"] = "true";
            return View(model);
        }

        // Settings Pages
        public IActionResult Settings()
        {
            return View("SettingsMenu");
        }

        public IActionResult LanguageSettings()
        {
            ViewData["ShowBackButton"] = "true";
            var model = new SettingsVM { SelectedLanguage = "English (Default)" };
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveLanguage(SettingsVM model)
        {
            TempData["Message"] = $"Language set to {model.SelectedLanguage}.";
            return RedirectToAction(nameof(Settings));
        }

        public IActionResult SecuritySettings()
        {
            ViewData["ShowBackButton"] = "true";
            var model = new SettingsVM { EnableFingerprintLogin = true };
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveSecurity(SettingsVM model)
        {
            TempData["Message"] = $"Fingerprint Login {(model.EnableFingerprintLogin ? "Enabled" : "Disabled")}.";
            return RedirectToAction(nameof(Settings));
        }

        public IActionResult HelpAndSupport()
        {
            ViewData["ShowBackButton"] = "true";
            var model = new SettingsVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitSupportQuestion(SettingsVM model)
        {
            TempData["Message"] = "Your question has been submitted to the support team.";
            return RedirectToAction(nameof(HelpAndSupport));
        }
    }
}
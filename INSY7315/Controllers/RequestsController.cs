using AfterGrad.Models;
using Microsoft.AspNetCore.Mvc; // <-- FIX: Added missing using statement

namespace AfterGrad.Controllers
{
    public class RequestsController : Controller
    {
        // Simulated List of Requests MUST be defined INSIDE the class
        private List<RequestVM> GetRequests() => new List<RequestVM>
        {
            new RequestVM { RequestID = "#031688890", RequestType = "Research analysis", StudentID = "ST10143579", Status = "Pending" },
            new RequestVM { RequestID = "#031688891", RequestType = "Essay Review", StudentID = "ST10143580", Status = "Pending" },
            new RequestVM { RequestID = "#031688892", RequestType = "Coding Help", StudentID = "ST10143581", Status = "Pending" }
        };

        // Simulated data for the details/assignment view
        private RequestVM GetRequestDetails(string id)
        {
            var consultants = new List<ConsultantVM>
            {
                new ConsultantVM { ConID = "CT90001", Name = "Michael Sansone", Services = "Research Analysis", NoOfAssignedServices = 5 },
                new ConsultantVM { ConID = "CT90002", Name = "Sarah Jones", Services = "Research Analysis", NoOfAssignedServices = 9 }
            };

            return new RequestVM
            {
                RequestID = id,
                RequestType = "Research analysis",
                StudentID = "ST10143579",
                Status = "Pending",
                DocName = "sync_01.pdf",
                DateSubmitted = new DateTime(2023, 08, 16, 9, 45, 0),
                Feedback = "No Feedback",
                AvailableConsultants = consultants
            };
        }

        // Action method starts here
        public IActionResult Index()
        {
            // The method 'View' is now recognized.
            return View(GetRequests()); // Error CS0103/CS0116 fixed
        }

        public IActionResult Details(string id)
        {
            ViewData["ShowBackButton"] = "true";

            var model = GetRequestDetails(id); // Error CS0103/CS0116 fixed
            // The method 'View' is now recognized.
            return View(model); // Error CS0103/CS0116 fixed
        }

        [HttpPost]
        public IActionResult AssignConsultant(string requestId, string consultantId)
        {
            // TempData is recognized because of Microsoft.AspNetCore.Mvc
            TempData["Message"] = $"Consultant {consultantId} assigned to Request {requestId} successfully.";
            // RedirectToAction is recognized because of Microsoft.AspNetCore.Mvc
            return RedirectToAction(nameof(Index)); // Error CS0103 fixed
        }

        [HttpPost]
        public IActionResult DeclineRequest(string id)
        {
            // TempData is recognized because of Microsoft.AspNetCore.Mvc
            TempData["Message"] = $"Request {id} has been declined.";
            // RedirectToAction is recognized because of Microsoft.AspNetCore.Mvc
            return RedirectToAction(nameof(Index)); // Error CS0103 fixed
        }
    }
}
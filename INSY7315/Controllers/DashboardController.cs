using AfterGrad.Models;
using Microsoft.AspNetCore.Mvc;

namespace AfterGrad.Controllers
{
    public class DashboardController : Controller
    {
        // Simulated Data (replace with actual service/DB calls)
        private DashboardSummaryVM GetDashboardData()
        {
            return new DashboardSummaryVM
            {
                PendingRequestsCount = 69,
                AvailableConsultantsCount = 5,
                RecentUploads = new List<ResourceVM>
                {
                    new ResourceVM { Title = "Thesis Formatting Guide", Type = "PDF", Description = "University Standard" },
                    new ResourceVM { Title = "Data Analysis Templates", Type = "Excel", Description = "Statistical Methods" }
                },
                RecentRequests = new List<RequestVM>
                {
                    new RequestVM { RequestID = "#031688890", RequestType = "Research analysis", StudentID = "ST10143579", Status = "Pending" },
                    new RequestVM { RequestID = "#031688891", RequestType = "Essay Review", StudentID = "ST10143580", Status = "Pending" }
                }
            };
        }

        public IActionResult Index()
        {
            var model = GetDashboardData();
            return View(model);
        }
    }
}
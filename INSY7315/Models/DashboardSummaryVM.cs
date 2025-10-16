namespace AfterGrad.Models
{
    public class DashboardSummaryVM
    {
        public int PendingRequestsCount { get; set; } = 0;
        public int AvailableConsultantsCount { get; set; } = 0;
        public List<ResourceVM> RecentUploads { get; set; } = new List<ResourceVM>();
        public List<RequestVM> RecentRequests { get; set; } = new List<RequestVM>();
    }
}
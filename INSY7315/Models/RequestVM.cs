namespace AfterGrad.Models
{
    public class RequestVM
    {
        public string RequestID { get; set; } = string.Empty;
        public string RequestType { get; set; } = string.Empty; // e.g., "Research analysis"
        public string StudentID { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Always "Pending" on the main list
        public string DocName { get; set; } = string.Empty; // For Details View
        public DateTime DateSubmitted { get; set; } = DateTime.Now; // For Details View
        public string Feedback { get; set; } = string.Empty; // For Details View
        public List<ConsultantVM> AvailableConsultants { get; set; } = new List<ConsultantVM>(); // For Details View
    }
}
namespace AfterGrad.Models
{
    public class ConsultantVM
    {
        public string ConID { get; set; } = string.Empty; // e.g., "CT90001"
        public string Name { get; set; } = string.Empty; // e.g., "Michael Sansone"
        public string Services { get; set; } = string.Empty; // e.g., "Research Analysis"
        public int NoOfAssignedServices { get; set; } = 0;
        public bool IsSelected { get; set; } = false; // For checkbox in Assign page
    }
}
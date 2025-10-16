using System.ComponentModel.DataAnnotations;

namespace AfterGrad.Models
{
    public class SettingsVM
    {
        // Language Settings
        public string SelectedLanguage { get; set; } = "English (Default)";
        public List<string> AvailableLanguages { get; set; } = new List<string> { "English (Default)", "Spanish", "French" };

        // Security Settings
        public bool EnableFingerprintLogin { get; set; } = false;

        // Help & Support (FAQs & Contact)
        public List<string> FAQs { get; set; } = new List<string>
        {
            "How do I request a service as a student?",
            "How will I know when my consultant uploads feedback?",
            "Can I chat directly with my consultant?"
        };
        public string SupportQuestion { get; set; } = string.Empty;
    }
}
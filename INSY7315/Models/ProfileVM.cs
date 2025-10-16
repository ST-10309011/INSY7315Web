using System.ComponentModel.DataAnnotations;

namespace AfterGrad.Models
{
    public class ProfileVM
    {
        public string Username { get; set; } = "vicky_M"; // Simulated default

        [EmailAddress]
        public string Email { get; set; } = "vicky_M@gmail.com"; // Simulated default

        // This is only used for the 'Edit Profile' form input
        public string NewUsername { get; set; } = string.Empty;
        public string NewEmail { get; set; } = string.Empty;
    }
}
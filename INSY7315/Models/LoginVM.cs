using System.ComponentModel.DataAnnotations;

namespace AfterGrad.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        // Note: Fingerprint login will be handled client-side (mobile) but the server needs this structure.
    }
}